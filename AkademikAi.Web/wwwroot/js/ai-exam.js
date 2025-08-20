document.addEventListener('DOMContentLoaded', function () {
    initializeAiExamForm();
});

function initializeAiExamForm() {
    const customExamForm = document.getElementById('customExamForm');
    if (!customExamForm) return;

    // Form submit event
    customExamForm.addEventListener('submit', handleAiExamSubmit);

    // Subject change event for dynamic topic loading
    const subjectSelect = document.getElementById('exam-subject');
    if (subjectSelect) {
        subjectSelect.addEventListener('change', loadTopicsForSubject);
    }

    // Initial topic loading if subject is pre-selected
    if (subjectSelect && subjectSelect.value) {
        loadTopicsForSubject();
    }
}

async function loadTopicsForSubject() {
    const subjectSelect = document.getElementById('exam-subject');
    const topicSelect = document.getElementById('exam-topic');
    
    if (!subjectSelect || !topicSelect) return;

    const subjectId = subjectSelect.value;
    if (!subjectId) {
        topicSelect.innerHTML = '<option value="">Önce ders seçiniz</option>';
        return;
    }

    try {
        // Show loading state
        topicSelect.innerHTML = '<option value="">Yükleniyor...</option>';
        topicSelect.disabled = true;

        const response = await fetch(`/User/GetTopicsBySubject?subjectId=${subjectId}`);
        const data = await response.json();

        if (data.success && data.topics) {
            topicSelect.innerHTML = '<option value="">Konu Seçin</option>';
            data.topics.forEach(topic => {
                const option = document.createElement('option');
                option.value = topic.id;
                option.textContent = topic.topicName;
                topicSelect.appendChild(option);
            });
        } else {
            topicSelect.innerHTML = '<option value="">Konu bulunamadı</option>';
        }
    } catch (error) {
        console.error('Konular yüklenirken hata:', error);
        topicSelect.innerHTML = '<option value="">Hata oluştu</option>';
    } finally {
        topicSelect.disabled = false;
    }
}

async function handleAiExamSubmit(e) {
    e.preventDefault();

    const form = e.target;
    const submitButton = form.querySelector('button[type="submit"]');
    const originalButtonText = submitButton.innerHTML;

    try {
        // Get form data
        const formData = new FormData(form);
        const examData = {
            TestName: formData.get('TestName'),
            SubjectId: formData.get('SubjectId'),
            TopicId: formData.get('TopicId'),
            QuestionCount: parseInt(formData.get('QuestionCount')),
            DurationMinutes: parseInt(formData.get('DurationMinutes')),
            Difficulty: parseInt(formData.get('Difficulty'))
        };

        // Validate form data
        if (!validateExamData(examData)) {
            return;
        }

        // Show detailed loading modal
        showAiLoadingModal(examData.QuestionCount);
        
        // Disable form and show loading
        setFormLoadingState(form, true, 'AI Sorular Üretiliyor...');

        // Submit to AI exam creation endpoint
        const response = await fetch('/User/CreateCustomExamWithAi', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            body: JSON.stringify(examData)
        });

        const result = await response.json();

        // Hide loading modal
        hideAiLoadingModal();

        if (result.success) {
            showSuccessMessage('AI ile test başarıyla oluşturuldu! Sınava yönlendiriliyorsunuz...');
            
            // Redirect to exam after a short delay
            setTimeout(() => {
                window.location.href = `/User/Solve?examId=${result.examId}`;
            }, 2000);
        } else {
            showErrorMessage(result.message || 'Test oluşturulurken bir hata oluştu.');
        }

    } catch (error) {
        console.error('AI test oluşturma hatası:', error);
        hideAiLoadingModal();
        showErrorMessage('AI servisi ile iletişim kurulamadı. Lütfen tekrar deneyin.');
    } finally {
        // Restore form state
        setFormLoadingState(form, false, originalButtonText);
    }
}

function validateExamData(data) {
    if (!data.TestName || data.TestName.trim().length < 3) {
        showErrorMessage('Test adı en az 3 karakter olmalıdır.');
        return false;
    }

    if (!data.SubjectId) {
        showErrorMessage('Lütfen bir ders seçin.');
        return false;
    }

    if (!data.TopicId) {
        showErrorMessage('Lütfen bir konu seçin.');
        return false;
    }

    if (data.QuestionCount < 5 || data.QuestionCount > 50) {
        showErrorMessage('Soru sayısı 5-50 arasında olmalıdır.');
        return false;
    }

    if (data.DurationMinutes < 10 || data.DurationMinutes > 180) {
        showErrorMessage('Süre 10-180 dakika arasında olmalıdır.');
        return false;
    }

    return true;
}

function setFormLoadingState(form, isLoading, buttonText) {
    const submitButton = form.querySelector('button[type="submit"]');
    const inputs = form.querySelectorAll('input, select');
    
    if (isLoading) {
        submitButton.innerHTML = `
            <div class="spinner-border spinner-border-sm me-2" role="status">
                <span class="visually-hidden">Yükleniyor...</span>
            </div>
            ${buttonText}
        `;
        submitButton.disabled = true;
        inputs.forEach(input => input.disabled = true);
    } else {
        submitButton.innerHTML = buttonText;
        submitButton.disabled = false;
        inputs.forEach(input => input.disabled = false);
    }
}

function showSuccessMessage(message) {
    showMessage(message, 'success');
}

function showErrorMessage(message) {
    showMessage(message, 'error');
}

function showMessage(message, type) {
    // Remove existing messages
    const existingMessage = document.querySelector('.ai-exam-message');
    if (existingMessage) {
        existingMessage.remove();
    }

    // Create message element
    const messageDiv = document.createElement('div');
    messageDiv.className = `ai-exam-message ai-exam-message-${type}`;
    messageDiv.innerHTML = `
        <div class="message-content">
            <i class="fas fa-${type === 'success' ? 'check-circle' : 'exclamation-circle'}"></i>
            <span>${message}</span>
        </div>
        <button type="button" class="message-close" onclick="this.parentElement.remove()">
            <i class="fas fa-times"></i>
        </button>
    `;

    // Insert message after form
    const form = document.getElementById('customExamForm');
    if (form) {
        form.parentNode.insertBefore(messageDiv, form.nextSibling);
    }

    // Auto-remove success messages after 5 seconds
    if (type === 'success') {
        setTimeout(() => {
            if (messageDiv.parentNode) {
                messageDiv.remove();
            }
        }, 5000);
    }
}

// Add CSS for messages
const style = document.createElement('style');
style.textContent = `
    .ai-exam-message {
        padding: 12px 16px;
        margin: 16px 0;
        border-radius: 8px;
        display: flex;
        align-items: center;
        justify-content: space-between;
        font-size: 14px;
        font-weight: 500;
    }

    .ai-exam-message-success {
        background-color: #d4edda;
        color: #155724;
        border: 1px solid #c3e6cb;
    }

    .ai-exam-message-error {
        background-color: #f8d7da;
        color: #721c24;
        border: 1px solid #f5c6cb;
    }

    .ai-exam-message .message-content {
        display: flex;
        align-items: center;
        gap: 8px;
    }

    .ai-exam-message .message-close {
        background: none;
        border: none;
        color: inherit;
        cursor: pointer;
        padding: 4px;
        border-radius: 4px;
        transition: background-color 0.2s;
    }

    .ai-exam-message .message-close:hover {
        background-color: rgba(0, 0, 0, 0.1);
    }

    .spinner-border {
        width: 1rem;
        height: 1rem;
    }

    /* AI Loading Modal Styles */
    .ai-loading-modal {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.8);
        display: flex;
        justify-content: center;
        align-items: center;
        z-index: 9999;
    }

    .ai-loading-content {
        background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
        color: white;
        padding: 40px;
        border-radius: 20px;
        text-align: center;
        max-width: 500px;
        width: 90%;
        box-shadow: 0 20px 40px rgba(0, 0, 0, 0.3);
    }

    .ai-loading-title {
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 20px;
        display: flex;
        align-items: center;
        justify-content: center;
        gap: 10px;
    }

    .ai-loading-progress {
        margin: 20px 0;
    }

    .ai-loading-bar {
        width: 100%;
        height: 8px;
        background-color: rgba(255, 255, 255, 0.3);
        border-radius: 4px;
        overflow: hidden;
        margin-bottom: 10px;
    }

    .ai-loading-fill {
        height: 100%;
        background: linear-gradient(90deg, #fff, #e0e0e0, #fff);
        background-size: 200% 100%;
        animation: ai-loading-animation 2s infinite;
        width: 0%;
        transition: width 0.5s ease;
    }

    @keyframes ai-loading-animation {
        0% { background-position: 200% 0; }
        100% { background-position: -200% 0; }
    }

    .ai-loading-steps {
        text-align: left;
        margin-top: 20px;
    }

    .ai-loading-step {
        padding: 8px 0;
        opacity: 0.6;
        transition: opacity 0.3s;
    }

    .ai-loading-step.active {
        opacity: 1;
        font-weight: 500;
    }

    .ai-loading-step.completed {
        opacity: 0.8;
        color: #90ee90;
    }

    .ai-robot-icon {
        font-size: 30px;
        animation: ai-robot-pulse 1.5s infinite;
    }

    @keyframes ai-robot-pulse {
        0%, 100% { transform: scale(1); }
        50% { transform: scale(1.1); }
    }
`;
document.head.appendChild(style);

// AI Loading Modal Functions
function showAiLoadingModal(questionCount) {
    const modal = document.createElement('div');
    modal.className = 'ai-loading-modal';
    modal.id = 'ai-loading-modal';
    
    modal.innerHTML = `
        <div class="ai-loading-content">
            <div class="ai-loading-title">
                <span class="ai-robot-icon">🤖</span>
                Yapay Zeka Soruları Hazırlıyor
            </div>
            
            <div class="ai-loading-progress">
                <div class="ai-loading-bar">
                    <div class="ai-loading-fill" id="ai-progress-fill"></div>
                </div>
                <div id="ai-progress-text">AI motoru başlatılıyor...</div>
            </div>
            
            <div class="ai-loading-steps">
                <div class="ai-loading-step" id="step-1">📚 Ders ve konu analiz ediliyor</div>
                <div class="ai-loading-step" id="step-2">🧠 ${questionCount} adet soru üretiliyor</div>
                <div class="ai-loading-step" id="step-3">✅ Sorular kontrol ediliyor</div>
                <div class="ai-loading-step" id="step-4">🎯 Test hazırlanıyor</div>
            </div>
        </div>
    `;
    
    document.body.appendChild(modal);
    
    // Start progress animation
    startAiLoadingAnimation();
}

function hideAiLoadingModal() {
    const modal = document.getElementById('ai-loading-modal');
    if (modal) {
        modal.remove();
    }
}

function startAiLoadingAnimation() {
    const progressFill = document.getElementById('ai-progress-fill');
    const progressText = document.getElementById('ai-progress-text');
    const steps = ['step-1', 'step-2', 'step-3', 'step-4'];
    
    let currentStep = 0;
    let progress = 0;
    
    const interval = setInterval(() => {
        // Update progress bar
        progress += Math.random() * 15 + 5;
        if (progress > 95) progress = 95;
        
        progressFill.style.width = progress + '%';
        
        // Update steps
        if (progress > 25 && currentStep === 0) {
            document.getElementById(steps[0]).classList.add('active');
            progressText.textContent = 'Ders ve konu bilgileri analiz ediliyor...';
            currentStep++;
        } else if (progress > 50 && currentStep === 1) {
            document.getElementById(steps[0]).classList.remove('active');
            document.getElementById(steps[0]).classList.add('completed');
            document.getElementById(steps[1]).classList.add('active');
            progressText.textContent = 'AI soruları üretiyor...';
            currentStep++;
        } else if (progress > 75 && currentStep === 2) {
            document.getElementById(steps[1]).classList.remove('active');
            document.getElementById(steps[1]).classList.add('completed');
            document.getElementById(steps[2]).classList.add('active');
            progressText.textContent = 'Sorular kontrol ediliyor...';
            currentStep++;
        } else if (progress > 90 && currentStep === 3) {
            document.getElementById(steps[2]).classList.remove('active');
            document.getElementById(steps[2]).classList.add('completed');
            document.getElementById(steps[3]).classList.add('active');
            progressText.textContent = 'Test hazırlanıyor...';
            currentStep++;
        }
        
        if (progress >= 95) {
            clearInterval(interval);
        }
    }, 300);
}
