        let selectedOption = null;
        let currentQuestionIndex = 0;
        let questions = [];
        let totalQuestions = 0;
        let timeLeft = 15 * 60; // 15 dakika
        let timerInterval;

        // Timer functionality
        function updateTimer() {
            const minutes = Math.floor(timeLeft / 60);
            const seconds = timeLeft % 60;
            document.getElementById('timer').textContent = 
                `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
            
            if (timeLeft <= 0) {
                clearInterval(timerInterval);
                alert('Süre doldu! Sınav otomatik olarak sonlandırılıyor.');
                window.location.href = '/User/Dashboard';
                return;
            }
            
            timeLeft--;
        }

        // Ana konu değiştiğinde alt konuları yükle
        document.getElementById('course-filter').addEventListener('change', function() {
            const mainTopicId = this.value;
            const subTopicSelect = document.getElementById('topic-filter');
            
            if (mainTopicId) {
                // Alt konuları yükle
                fetch(`/User/GetSubTopics?parentTopicId=${mainTopicId}`)
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            subTopicSelect.innerHTML = '<option value="">Tüm Alt Konular</option>';
                            data.subTopics.forEach(topic => {
                                subTopicSelect.innerHTML += `<option value="${topic.id}">${topic.name}</option>`;
                            });
                            subTopicSelect.disabled = false;
                        } else {
                            subTopicSelect.innerHTML = '<option value="">Alt konu bulunamadı</option>';
                            subTopicSelect.disabled = true;
                        }
                    })
                    .catch(error => {
                        console.error('Alt konular yüklenirken hata:', error);
                        subTopicSelect.innerHTML = '<option value="">Hata oluştu</option>';
                        subTopicSelect.disabled = true;
                    });
            } else {
                subTopicSelect.innerHTML = '<option value="">Önce ana konu seçin</option>';
                subTopicSelect.disabled = true;
            }
        });

        // Soruları yükle butonu
        document.getElementById('loadQuestions').addEventListener('click', function() {
            const mainTopicId = document.getElementById('course-filter').value;
            const subTopicId = document.getElementById('topic-filter').value;
            
            // Hangi topic ID'sini kullanacağımızı belirle
            const topicId = subTopicId || mainTopicId;
            
            if (!topicId) {
                alert('Lütfen bir konu seçin!');
                return;
            }

            // Loading göster
            this.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Yükleniyor...';
            this.disabled = true;

            // Soruları getir
            fetch(`/User/GetFilteredQuestions?topicId=${topicId}`)
                .then(response => response.json())
                .then(data => {
                    if (data.success && data.questions.length > 0) {
                        questions = data.questions;
                        totalQuestions = questions.length;
                        currentQuestionIndex = 0;
                        
                        updateQuestionDisplay();
                        updateProgress();
                        
                        if (timerInterval) clearInterval(timerInterval);
                        timeLeft = 15 * 60;
                        timerInterval = setInterval(updateTimer, 1000);
                        
                        const selectedOption = document.getElementById('course-filter').options[document.getElementById('course-filter').selectedIndex];
                        document.getElementById('currentTopic').textContent = selectedOption.text;
                        
                        document.getElementById('prevQuestion').disabled = false;
                        document.getElementById('nextQuestion').disabled = false;
                        
                    } else {
                        alert('Seçilen konuda soru bulunamadı!');
                    }
                })
                .catch(error => {
                    console.error('Sorular yüklenirken hata:', error);
                    alert('Sorular yüklenirken hata oluştu!');
                })
                .finally(() => {
                    // Loading'i kaldır
                    this.innerHTML = '<i class="fas fa-search"></i> Soruları Yükle';
                    this.disabled = false;
                });
        });

        function updateQuestionDisplay() {
            if (questions.length === 0) return;
            
            const question = questions[currentQuestionIndex];
            
            // Soru başlığını güncelle
            document.getElementById('questionTitle').textContent = `Soru ${currentQuestionIndex + 1}`;
            document.getElementById('questionText').textContent = question.questionText;
            
            // Seçenekleri oluştur
            const optionsContainer = document.getElementById('optionsContainer');
            optionsContainer.innerHTML = '';
            
            if (question.options && question.options.length > 0) {
                question.options.forEach(option => {
                    const optionBtn = document.createElement('button');
                    optionBtn.className = 'option-btn';
                    optionBtn.setAttribute('data-option', option.label);
                    optionBtn.setAttribute('data-correct', option.isCorrect);
                    
                    optionBtn.innerHTML = `
                        <span class="option-label">${option.label}</span>
                        <span class="option-text">${option.text}</span>
                    `;
                    
                    optionBtn.addEventListener('click', function() {
                        handleOptionSelection(this);
                    });
                    
                    optionsContainer.appendChild(optionBtn);
                });
            }
            
            if (question.solutionText) {
                document.getElementById('solutionText').textContent = question.solutionText;
            }
            
            const correctOption = question.options?.find(o => o.isCorrect);
            if (correctOption) {
                document.getElementById('correctAnswer').innerHTML = `<strong>Doğru Cevap: ${correctOption.label}) ${correctOption.text}</strong>`;
            }
            
            document.getElementById('currentQuestionNumber').textContent = currentQuestionIndex + 1;
            document.getElementById('totalQuestions').textContent = totalQuestions;
        }

        function handleOptionSelection(selectedButton) {
            document.querySelectorAll('.option-btn').forEach(btn => {
                btn.classList.remove('selected', 'correct', 'incorrect');
            });
            
            selectedButton.classList.add('selected');
            selectedOption = selectedButton.getAttribute('data-option');
            
            setTimeout(() => {
                const isCorrect = selectedButton.getAttribute('data-correct') === 'true';
                if (isCorrect) {
                    selectedButton.classList.add('correct');
                } else {
                    selectedButton.classList.add('incorrect');
                    document.querySelectorAll('.option-btn').forEach(btn => {
                        if (btn.getAttribute('data-correct') === 'true') {
                            btn.classList.add('correct');
                        }
                    });
                }
            }, 500);
        }

        function updateProgress() {
            const progressPercentage = totalQuestions > 0 ? ((currentQuestionIndex + 1) / totalQuestions) * 100 : 0;
            document.querySelector('.progress-fill').style.width = `${progressPercentage}%`;
            document.querySelector('.progress-text').textContent = `${currentQuestionIndex + 1} / ${totalQuestions} soru tamamlandı`;
        }

        document.getElementById('showSolution').addEventListener('click', function() {
            document.getElementById('solutionArea').style.display = 'block';
            this.style.display = 'none';
        });

        document.getElementById('closeSolution').addEventListener('click', function() {
            document.getElementById('solutionArea').style.display = 'none';
            document.getElementById('showSolution').style.display = 'inline-flex';
        });

        document.getElementById('prevQuestion').addEventListener('click', function() {
            if (currentQuestionIndex > 0) {
                currentQuestionIndex--;
                updateQuestionDisplay();
                updateProgress();
                resetQuestion();
            }
        });

        document.getElementById('nextQuestion').addEventListener('click', function() {
            if (currentQuestionIndex < totalQuestions - 1) {
                currentQuestionIndex++;
                updateQuestionDisplay();
                updateProgress();
                resetQuestion();
            } else {
                alert('Son soruya ulaştınız! Sınavı tamamlamak istiyor musunuz?');
            }
        });

        function resetQuestion() {
            document.querySelectorAll('.option-btn').forEach(btn => {
                btn.classList.remove('selected', 'correct', 'incorrect');
            });
            
            document.getElementById('solutionArea').style.display = 'none';
            document.getElementById('showSolution').style.display = 'inline-flex';
            
            selectedOption = null;
        }

        document.querySelector('.btn-exit').addEventListener('click', function() {
            if (confirm('Sınavdan çıkmak istediğinizden emin misiniz? İlerlemeniz kaydedilecek.')) {
                if (timerInterval) clearInterval(timerInterval);
                window.location.href = '/User/Dashboard';
            }
        });

        document.addEventListener('DOMContentLoaded', function() {
            updateTimer();
        });