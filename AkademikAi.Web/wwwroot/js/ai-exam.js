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
        // Disable form and show loading
        setFormLoadingState(form, true, 'AI Sorular Üretiliyor...');

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
`;
document.head.appendChild(style);
