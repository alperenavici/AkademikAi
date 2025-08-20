#!/usr/bin/env python3
"""
AI Test Soru Üretim Servisi Örneği
Bu dosya, localhost:8000 portunda çalışan basit bir AI servis örneğidir.
"""

from flask import Flask, request, jsonify
from flask_cors import CORS
import random
import json

app = Flask(__name__)
CORS(app)  # Cross-origin resource sharing için

# Örnek soru veritabanı
SAMPLE_QUESTIONS = {
    "Matematik": {
        "Geometri": {
            "easy": [
                {
                    "question": "Bir üçgenin iç açıları toplamı kaç derecedir?",
                    "options": ["90", "180", "270", "360"],
                    "correct_answer": "180",
                    "explanation": "Bir üçgenin iç açıları toplamı her zaman 180 derecedir."
                },
                {
                    "question": "Bir karenin çevresi nasıl hesaplanır?",
                    "options": ["Kenar × 2", "Kenar × 3", "Kenar × 4", "Kenar × 5"],
                    "correct_answer": "Kenar × 4",
                    "explanation": "Karenin tüm kenarları eşit olduğu için çevre = 4 × kenar uzunluğu"
                }
            ],
            "medium": [
                {
                    "question": "Bir dik üçgende hipotenüsün karesi neye eşittir?",
                    "options": ["Dik kenarların toplamı", "Dik kenarların çarpımı", "Dik kenarların kareleri toplamı", "Dik kenarların farkı"],
                    "correct_answer": "Dik kenarların kareleri toplamı",
                    "explanation": "Pisagor teoremine göre: a² + b² = c²"
                }
            ],
            "hard": [
                {
                    "question": "Bir dairenin alanı formülü nedir?",
                    "options": ["πr", "πr²", "2πr", "πr³"],
                    "correct_answer": "πr²",
                    "explanation": "Dairenin alanı = π × yarıçap²"
                }
            ]
        },
        "Cebir": {
            "easy": [
                {
                    "question": "2x + 3 = 7 denkleminde x kaçtır?",
                    "options": ["1", "2", "3", "4"],
                    "correct_answer": "2",
                    "explanation": "2x + 3 = 7 → 2x = 4 → x = 2"
                }
            ],
            "medium": [
                {
                    "question": "(x + 2)² ifadesi hangisine eşittir?",
                    "options": ["x² + 4", "x² + 2x + 4", "x² + 4x + 4", "x² + 4x + 2"],
                    "correct_answer": "x² + 4x + 4",
                    "explanation": "(a + b)² = a² + 2ab + b² formülü kullanılır"
                }
            ]
        }
    },
    "Fizik": {
        "Mekanik": {
            "easy": [
                {
                    "question": "Hız birimi nedir?",
                    "options": ["m/s", "m/s²", "N", "J"],
                    "correct_answer": "m/s",
                    "explanation": "Hız = mesafe / zaman olduğu için birimi m/s'dir"
                }
            ],
            "medium": [
                {
                    "question": "Newton'un ikinci yasası nedir?",
                    "options": ["F = ma", "F = mg", "F = mv", "F = m/t"],
                    "correct_answer": "F = ma",
                    "explanation": "Kuvvet = kütle × ivme"
                }
            ]
        }
    }
}

def generate_questions(subject, topic, difficulty, question_count):
    """Belirtilen kriterlere göre soru üretir"""
    
    # Mevcut soruları kontrol et
    if subject not in SAMPLE_QUESTIONS:
        return []
    
    if topic not in SAMPLE_QUESTIONS[subject]:
        return []
    
    if difficulty not in SAMPLE_QUESTIONS[subject][topic]:
        return []
    
    available_questions = SAMPLE_QUESTIONS[subject][topic][difficulty]
    
    # Eğer yeterli soru yoksa, mevcut olanları döndür
    if len(available_questions) <= question_count:
        return available_questions
    
    # Rastgele soru seç
    selected_questions = random.sample(available_questions, question_count)
    return selected_questions

def generate_ai_questions(subject, topic, difficulty, question_count):
    """AI benzeri soru üretimi (gerçek AI entegrasyonu için placeholder)"""
    
    # Mevcut sorulardan seç
    base_questions = generate_questions(subject, topic, difficulty, question_count)
    
    # AI tarafından üretilmiş gibi varyasyonlar ekle
    ai_questions = []
    for q in base_questions:
        # Soru metnini biraz değiştir
        question_text = q["question"]
        if "üçgen" in question_text.lower():
            question_text = question_text.replace("üçgen", "geometrik şekil")
        elif "kare" in question_text.lower():
            question_text = question_text.replace("kare", "dörtgen")
        
        ai_question = {
            "question": question_text,
            "options": q["options"],
            "correct_answer": q["correct_answer"],
            "explanation": q["explanation"]
        }
        ai_questions.append(ai_question)
    
    return ai_questions

@app.route('/generate_questions', methods=['POST'])
def generate_questions_endpoint():
    """Soru üretimi endpoint'i"""
    
    try:
        data = request.get_json()
        
        # Gerekli alanları kontrol et
        required_fields = ['subject', 'topic', 'difficulty', 'question_count']
        for field in required_fields:
            if field not in data:
                return jsonify({
                    'error': f'Eksik alan: {field}',
                    'status': 'error'
                }), 400
        
        subject = data['subject']
        topic = data['topic']
        difficulty = data['difficulty']
        question_count = int(data['question_count'])
        
        # Parametreleri doğrula
        if question_count < 1 or question_count > 50:
            return jsonify({
                'error': 'Soru sayısı 1-50 arasında olmalıdır',
                'status': 'error'
            }), 400
        
        if difficulty not in ['easy', 'medium', 'hard', 'mixed']:
            return jsonify({
                'error': 'Geçersiz zorluk seviyesi',
                'status': 'error'
            }), 400
        
        # Karışık zorluk için rastgele seç
        if difficulty == 'mixed':
            difficulty = random.choice(['easy', 'medium', 'hard'])
        
        # Soruları üret
        questions = generate_ai_questions(subject, topic, difficulty, question_count)
        
        if not questions:
            return jsonify({
                'error': f'{subject} dersinin {topic} konusunda {difficulty} zorlukta soru bulunamadı',
                'status': 'error'
            }), 404
        
        return jsonify(questions)
        
    except Exception as e:
        return jsonify({
            'error': f'Soru üretimi sırasında hata: {str(e)}',
            'status': 'error'
        }), 500

@app.route('/health', methods=['GET'])
def health_check():
    """Sağlık kontrolü endpoint'i"""
    return jsonify({
        'status': 'healthy',
        'service': 'AI Question Generator',
        'version': '1.0.0'
    })

@app.route('/', methods=['GET'])
def home():
    """Ana sayfa"""
    return jsonify({
        'message': 'AI Test Soru Üretim Servisi',
        'endpoints': {
            'generate_questions': 'POST /generate_questions',
            'health': 'GET /health'
        },
        'usage': {
            'method': 'POST',
            'url': '/generate_questions',
            'body': {
                'subject': 'string (örn: Matematik)',
                'topic': 'string (örn: Geometri)',
                'difficulty': 'string (easy/medium/hard/mixed)',
                'question_count': 'integer (1-50)',
                'question_type': 'string (opsiyonel)'
            }
        }
    })

if __name__ == '__main__':
    print("🤖 AI Test Soru Üretim Servisi başlatılıyor...")
    print("📍 Port: 8000")
    print("🌐 URL: http://localhost:8000")
    print("📚 Kullanılabilir dersler:", list(SAMPLE_QUESTIONS.keys()))
    print("=" * 50)
    
    app.run(host='0.0.0.0', port=8000, debug=True)
