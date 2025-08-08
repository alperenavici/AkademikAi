// Global variables
let examData = null;
let currentQuestionIndex = 0;
let userAnswers = {};
let timeRemaining = 0;
let timerInterval = null;
let examStartTime = Date.now();

document.addEventListener('DOMContentLoaded', function () {
    const examIdElement = document.getElementById('exam-id');
    const examId = examIdElement ? examIdElement.value : null;
    
    // Load exam data
    loadExamData(examId);
    
    // Initialize event listeners
    initializeEventListeners();
});

function loadExamData(examId) {
    if (!examId) {
        showError('Geçersiz sınav ID\'si. Lütfen sınavlar sayfasına dönün.');
        return;
    }

    fetch(`/User/StartAndGetExam?examId=${examId}`)
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                examData = data.exam;
                initializeExam();
            } else {
                showError(data.message || 'Sınav yüklenirken bir hata oluştu.');
            }
        })
        .catch(error => {
            console.error('Sınav yüklenirken hata:', error);
            showError('Sınav yüklenirken beklenmedik bir hata oluştu.');
        });
}

function initializeExam() {
    // Hide loading screen
    document.getElementById('exam-loading').style.display = 'none';
    document.getElementById('exam-container').style.display = 'block';

    // Set exam info
    document.getElementById('exam-title').textContent = examData.title;
    document.getElementById('exam-description').textContent = examData.description || '';
    document.getElementById('total-questions').textContent = examData.questions.length;

    // Initialize timer
    timeRemaining = examData.durationMinutes * 60; // Convert to seconds
    startTimer();

    // Generate question grid
    generateQuestionGrid();

    // Load first question
    loadQuestion(0);

    // Update navigation
    updateNavigation();
}

function initializeEventListeners() {
    // Navigation buttons
    const prevBtn = document.getElementById('prev-button');
    const nextBtn = document.getElementById('next-button');
    
    if (prevBtn) {
        prevBtn.addEventListener('click', () => {
            if (currentQuestionIndex > 0) {
                saveCurrentAnswer();
                loadQuestion(currentQuestionIndex - 1);
            }
        });
    }

    if (nextBtn) {
        nextBtn.addEventListener('click', () => {
            if (examData && currentQuestionIndex < examData.questions.length - 1) {
                saveCurrentAnswer();
                loadQuestion(currentQuestionIndex + 1);
            }
        });
    }

    // Question grid toggle
    const gridBtn = document.getElementById('question-grid-btn');
    if (gridBtn) {
        gridBtn.addEventListener('click', showQuestionGrid);
    }

    // Finish exam button
    const finishBtn = document.getElementById('finish-exam-btn');
    if (finishBtn) {
        finishBtn.addEventListener('click', confirmFinishExam);
    }

    // Keyboard navigation
    document.addEventListener('keydown', handleKeyboardNavigation);

    // Prevent page refresh
    window.addEventListener('beforeunload', function (e) {
        if (examData && timeRemaining > 0) {
            e.preventDefault();
            e.returnValue = '';
        }
    });
}

function loadQuestion(index) {
    if (!examData || index < 0 || index >= examData.questions.length) return;

    currentQuestionIndex = index;
    const question = examData.questions[index];

    // Create question HTML
    const questionCard = document.getElementById('question-card');
    if (!questionCard) return;

    questionCard.innerHTML = `
        <div class="question-header">
            <h2 class="question-number">Soru ${index + 1}</h2>
            <div class="question-info">
                <span class="question-type">Çoktan Seçmeli</span>
            </div>
        </div>
        <div class="question-body">
            <div class="question-text">
                ${question.questionText}
            </div>
            <div class="options-container">
                ${question.options && question.options.map ? question.options.map((option, optionIndex) => `
                    <div class="option-item ${userAnswers[question.id] === option.id ? 'selected' : ''}" 
                         onclick="selectOption('${question.id}', '${option.id}', this)">
                        <div class="option-radio">
                            <span class="option-letter">${option.label || String.fromCharCode(65 + optionIndex)}</span>
                        </div>
                        <div class="option-content">
                            <span class="option-text">${option.optionText}</span>
                        </div>
                    </div>
                `).join('') : ''}
            </div>
        </div>
    `;

    // Update progress
    updateProgress();
    updateNavigation();
    updateQuestionGrid();
}

function selectOption(questionId, optionId, element) {
    // Remove previous selection
    const options = document.querySelectorAll('.option-item');
    options.forEach(opt => opt.classList.remove('selected'));

    // Add selection to clicked option
    element.classList.add('selected');

    // Save answer
    userAnswers[questionId] = optionId;

    // Update question grid
    updateQuestionGrid();
}

function saveCurrentAnswer() {
    const selectedOption = document.querySelector('.option-item.selected');
    if (selectedOption && examData) {
        const questionId = examData.questions[currentQuestionIndex].id;
        const onclickAttr = selectedOption.getAttribute('onclick');
        if (onclickAttr) {
            const match = onclickAttr.match(/'([^']*)',\s*'([^']*)'/);
            if (match && match[2]) {
                userAnswers[questionId] = match[2];
            }
        }
    }
}

function updateProgress() {
    const answered = Object.keys(userAnswers).length;
    const total = examData ? examData.questions.length : 0;
    const percentage = total > 0 ? Math.round((answered / total) * 100) : 0;

    const currentQuestionEl = document.getElementById('current-question');
    const progressPercentEl = document.getElementById('progress-percent');
    const progressFillEl = document.getElementById('progress-fill');

    if (currentQuestionEl) currentQuestionEl.textContent = currentQuestionIndex + 1;
    if (progressPercentEl) progressPercentEl.textContent = percentage;
    if (progressFillEl) progressFillEl.style.width = percentage + '%';
}

function updateNavigation() {
    const prevBtn = document.getElementById('prev-button');
    const nextBtn = document.getElementById('next-button');

    if (prevBtn) prevBtn.disabled = currentQuestionIndex === 0;
    if (nextBtn && examData) {
        nextBtn.disabled = currentQuestionIndex === examData.questions.length - 1;
        
        if (nextBtn.disabled) {
            nextBtn.innerHTML = '<i class="fas fa-flag-checkered"></i> Son Soru';
        } else {
            nextBtn.innerHTML = 'Sonraki <i class="fas fa-chevron-right"></i>';
        }
    }
}

function generateQuestionGrid() {
    const grid = document.getElementById('question-grid');
    if (!examData || !grid) return;

    grid.innerHTML = examData.questions.map((q, index) => `
        <button class="grid-item" onclick="loadQuestion(${index})" data-question="${index + 1}">
            ${index + 1}
        </button>
    `).join('');
}

function updateQuestionGrid() {
    const gridItems = document.querySelectorAll('.grid-item');
    if (!examData) return;
    
    gridItems.forEach((item, index) => {
        const questionId = examData.questions[index].id;
        item.classList.remove('answered', 'current');
        
        if (index === currentQuestionIndex) {
            item.classList.add('current');
        } else if (userAnswers[questionId]) {
            item.classList.add('answered');
        }
    });
}

function showQuestionGrid() {
    const modal = document.getElementById('question-grid-modal');
    if (modal) modal.style.display = 'flex';
}

function closeQuestionGrid() {
    const modal = document.getElementById('question-grid-modal');
    if (modal) modal.style.display = 'none';
}

function startTimer() {
    timerInterval = setInterval(() => {
        timeRemaining--;
        updateTimerDisplay();

        if (timeRemaining <= 0) {
            clearInterval(timerInterval);
            autoSubmitExam();
        }
    }, 1000);
}

function updateTimerDisplay() {
    const hours = Math.floor(timeRemaining / 3600);
    const minutes = Math.floor((timeRemaining % 3600) / 60);
    const seconds = timeRemaining % 60;

    const timerElement = document.getElementById('timer');
    if (!timerElement) return;

    if (hours > 0) {
        timerElement.textContent = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
    } else {
        timerElement.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
    }

    // Warning styles
    if (timeRemaining <= 300) { // 5 minutes
        timerElement.classList.add('timer-warning');
    }
    if (timeRemaining <= 60) { // 1 minute
        timerElement.classList.add('timer-critical');
    }
}

function confirmFinishExam() {
    saveCurrentAnswer();
    
    const answered = Object.keys(userAnswers).length;
    const total = examData ? examData.questions.length : 0;
    const unanswered = total - answered;

    let message = `Testi bitirmek istediğinizden emin misiniz?\n\n`;
    message += `Toplam Soru: ${total}\n`;
    message += `Cevaplanmış: ${answered}\n`;
    
    if (unanswered > 0) {
        message += `Cevaplanmamış: ${unanswered}\n\n`;
        message += `Cevaplanmamış sorular yanlış sayılacaktır.`;
    }

    if (confirm(message)) {
        submitExam();
    }
}

function submitExam() {
    clearInterval(timerInterval);
    
    const examIdElement = document.getElementById('exam-id');
    const examId = examIdElement ? examIdElement.value : null;

    if (!examId) {
        alert('Sınav ID bulunamadı. Lütfen sayfayı yenileyin.');
        return;
    }

    console.log('📤 Submitting exam:', examId);
    console.log('📝 User answers:', userAnswers);

    // Prepare answers for submission
    const answersArray = Object.entries(userAnswers).map(([questionId, optionId]) => ({
        questionId: questionId,
        selectedOptionId: optionId
    }));

    if (answersArray.length === 0) {
        if (!confirm('Hiç soru cevaplanmadı. Yine de testi bitirmek istiyor musunuz?')) {
            return;
        }
    }

    console.log('📋 Answers array:', answersArray);

    // Show loading
    showSubmitLoading();

    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    
    const headers = {
        'Content-Type': 'application/json'
    };
    
    if (token) {
        headers['RequestVerificationToken'] = token;
    }
    
    const submitData = {
        examId: examId,
        answers: answersArray
    };
    
    console.log('🚀 Sending data:', submitData);
    
    fetch('/User/SubmitExam', {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(submitData)
    })
    .then(response => {
        console.log('📨 Response status:', response.status);
        if (!response.ok) {
            throw new Error(`Server Error: ${response.status} - ${response.statusText}`);
        }
        return response.json();
    })
    .then(data => {
        console.log('✅ Response data:', data);
        if (data.success) {
            console.log('🎉 Test başarıyla kaydedildi!');
            showExamResults(data);
        } else {
            console.error('❌ Server Error:', data);
            alert('Hata: ' + (data.message || 'Bilinmeyen bir hata oluştu.'));
            hideSubmitLoading();
        }
    })
    .catch(error => {
        console.error('💥 Submit error:', error);
        alert('Sınav gönderilirken bir hata oluştu. Lütfen internet bağlantınızı kontrol edin ve tekrar deneyin.\n\nHata: ' + error.message);
        hideSubmitLoading();
    });
}

function autoSubmitExam() {
    alert('Süre doldu! Test otomatik olarak tamamlanıyor.');
    submitExam();
}

function showSubmitLoading() {
    const container = document.getElementById('exam-container');
    if (container) {
        container.innerHTML = `
            <div class="loading-container">
                <div class="loading-content">
                    <div class="loading-spinner">
                        <div class="spinner"></div>
                    </div>
                    <h2 class="loading-title">Test Değerlendiriliyor...</h2>
                    <p class="loading-text">Cevaplarınız kontrol ediliyor ve puanınız hesaplanıyor</p>
                </div>
            </div>
        `;
    }
}

function hideSubmitLoading() {
    // Restore exam container if needed
    location.reload();
}

function showExamResults(data) {
    const container = document.getElementById('exam-container');
    if (container) {
        container.innerHTML = `
            <div class="results-container">
                <div class="results-header">
                    <div class="results-icon">
                        <i class="fas fa-trophy"></i>
                    </div>
                    <h1 class="results-title">Test Tamamlandı!</h1>
                    <p class="results-subtitle">Başarıyla tamamladınız</p>
                </div>
                
                <div class="results-stats">
                    <div class="stat-card">
                        <div class="stat-value">${data.score ? data.score.toFixed(1) : '0.0'}</div>
                        <div class="stat-label">Puan</div>
                    </div>
                    <div class="stat-card">
                        <div class="stat-value">${data.correctAnswers || 0}</div>
                        <div class="stat-label">Doğru</div>
                    </div>
                    <div class="stat-card">
                        <div class="stat-value">${data.wrongAnswers || 0}</div>
                        <div class="stat-label">Yanlış</div>
                    </div>
                    <div class="stat-card">
                        <div class="stat-value">${data.successRate ? data.successRate.toFixed(0) : '0'}%</div>
                        <div class="stat-label">Başarı</div>
                    </div>
                </div>
                
                                    <div class="results-actions">
                        <a href="/User/Performance" class="btn-primary">
                            <i class="fas fa-chart-line"></i>
                            Performansımı Görüntüle
                        </a>
                        <a href="/User/Exams" class="btn-secondary">
                            <i class="fas fa-list"></i>
                            Sınavlar Sayfasına Dön
                        </a>
                    </div>
            </div>
        `;
    }
}

function showError(message) {
    const loadingEl = document.getElementById('exam-loading');
    if (loadingEl) {
        loadingEl.innerHTML = `
            <div class="error-container">
                <div class="error-icon">
                    <i class="fas fa-exclamation-triangle"></i>
                </div>
                <h2 class="error-title">Hata</h2>
                <p class="error-message">${message}</p>
                <a href="/User/Exams" class="btn-primary">
                    <i class="fas fa-arrow-left"></i>
                    Sınavlar Sayfasına Dön
                </a>
            </div>
        `;
    }
}

function confirmExitExam() {
    if (confirm('Testi yarıda bırakmak istediğinizden emin misiniz? Tüm ilerlemeniz kaybolacaktır.')) {
        window.location.href = '/User/Exams';
    }
}

function handleKeyboardNavigation(e) {
    if (e.ctrlKey || e.metaKey) return;
    
    switch(e.key) {
        case 'ArrowLeft':
            if (currentQuestionIndex > 0) {
                saveCurrentAnswer();
                loadQuestion(currentQuestionIndex - 1);
            }
            break;
        case 'ArrowRight':
            if (examData && currentQuestionIndex < examData.questions.length - 1) {
                saveCurrentAnswer();
                loadQuestion(currentQuestionIndex + 1);
            }
            break;
        case 'Escape':
            closeQuestionGrid();
            break;
        case 'Enter':
            if (e.target.classList.contains('option-item')) {
                e.target.click();
            }
            break;
    }
}

// Modal close on outside click
document.addEventListener('click', function(e) {
    const modal = document.getElementById('question-grid-modal');
    if (e.target === modal) {
        closeQuestionGrid();
    }
});
