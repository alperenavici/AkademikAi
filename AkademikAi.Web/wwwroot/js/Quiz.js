document.addEventListener('DOMContentLoaded', () => {
    // --- STATE (Durum Yönetimi) ---
    let currentQuestionIndex = 0;
    const totalQuestions = questionsData.length;
    const userAnswers = new Array(totalQuestions).fill(null);

    // --- DOM Referansları ---
    const topicNameEl = document.getElementById('topicName');
    const questionProgressEl = document.getElementById('questionProgress');
    const questionNumberEl = document.getElementById('questionNumber');
    const questionBodyEl = document.getElementById('questionBody');
    const questionImageContainerEl = document.getElementById('questionImageContainer');
    const optionsContainerEl = document.getElementById('optionsContainer');
    const solutionAreaEl = document.getElementById('solutionArea');
    const correctAnswerEl = document.getElementById('correctAnswer');
    const solutionTextEl = document.getElementById('solutionText');
    const progressFillEl = document.getElementById('progressFill');
    const progressTextEl = document.getElementById('progressText');

    // Butonlar
    const prevQuestionBtn = document.getElementById('prevQuestion');
    const nextQuestionBtn = document.getElementById('nextQuestion');
    const showSolutionBtn = document.getElementById('showSolution');
    const closeSolutionBtn = document.getElementById('closeSolution');

    // --- TEMEL FONKSİYON: Soruyu Ekrana Çiz ---
    function renderQuestion(index) {
        // Çözüm alanını her soruda gizle
        solutionAreaEl.style.display = 'none';
        const question = questionsData[index];
        const questionNumber = index + 1;

        // Header ve Progress bilgilerini güncelle
        topicNameEl.textContent = question.questionsTopics[0]?.topic.topicName || 'Genel';
        questionProgressEl.textContent = `Soru ${questionNumber} / ${totalQuestions}`;
        questionNumberEl.textContent = `Soru ${questionNumber}`;
        questionBodyEl.textContent = question.questionText;

        // Soru görselini yönet
        questionImageContainerEl.innerHTML = ''; // Önceki görseli temizle
        if (question.imageUrl) {
            const img = document.createElement('img');
            img.src = question.imageUrl;
            img.alt = "Soru Görseli";
            questionImageContainerEl.appendChild(img);
        }

        // Seçenekleri oluştur
        optionsContainerEl.innerHTML = '';
        const optionLabels = ['A', 'B', 'C', 'D', 'E'];
        question.options.forEach((option, i) => {
            const button = document.createElement('button');
            button.className = 'option-btn';
            button.dataset.option = option.id; // Seçeneğin ID'sini data attribute olarak sakla
            button.innerHTML = `
                <span class="option-label">${optionLabels[i]}</span>
                <span class="option-text">${option.optionText}</span>
            `;
            // Kullanıcı bu soruya daha önce cevap verdiyse, seçimini işaretle
            if (userAnswers[index] === option.id) {
                button.classList.add('selected');
            }
            optionsContainerEl.appendChild(button);
        });

        // Çözüm alanını doldur
        const correctOption = question.options.find(opt => opt.isCorrect);
        const correctOptionLabel = optionLabels[question.options.indexOf(correctOption)];
        correctAnswerEl.innerHTML = `<strong>Doğru Cevap: ${correctOptionLabel}) ${correctOption.optionText}</strong>`;
        solutionTextEl.textContent = question.solutionText;

        // İlerleme çubuğunu güncelle
        const progressPercentage = (questionNumber / totalQuestions) * 100;
        progressFillEl.style.width = `${progressPercentage}%`;
        progressTextEl.textContent = `${questionNumber} / ${totalQuestions} soru tamamlandı`;

        // Navigasyon butonlarının durumunu ayarla
        prevQuestionBtn.disabled = index === 0;
        nextQuestionBtn.disabled = index === totalQuestions - 1;
    }

    // --- EVENT LISTENERS (Olay Dinleyicileri) ---

    nextQuestionBtn.addEventListener('click', () => {
        if (currentQuestionIndex < totalQuestions - 1) {
            currentQuestionIndex++;
            renderQuestion(currentQuestionIndex);
        }
    });

    prevQuestionBtn.addEventListener('click', () => {
        if (currentQuestionIndex > 0) {
            currentQuestionIndex--;
            renderQuestion(currentQuestionIndex);
        }
    });

    showSolutionBtn.addEventListener('click', () => {
        solutionAreaEl.style.display = 'block';
    });

    closeSolutionBtn.addEventListener('click', () => {
        solutionAreaEl.style.display = 'none';
    });

    // Seçeneklere tıklandığında (Event Delegation kullanarak)
    optionsContainerEl.addEventListener('click', (e) => {
        const selectedBtn = e.target.closest('.option-btn');
        if (!selectedBtn) return;

        // Önceki seçimi kaldır
        optionsContainerEl.querySelectorAll('.option-btn').forEach(btn => btn.classList.remove('selected'));

        // Yeni seçimi işaretle
        selectedBtn.classList.add('selected');

        // Kullanıcının cevabını kaydet
        userAnswers[currentQuestionIndex] = selectedBtn.dataset.option;
        console.log(userAnswers); // Test için cevapları konsola yazdır
    });


    // --- BAŞLANGIÇ ---
    renderQuestion(currentQuestionIndex);
});