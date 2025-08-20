# AI ile Test Oluşturma Sistemi

Bu sistem, kullanıcıların belirli parametrelere göre yapay zeka destekli test oluşturmasını sağlar.

## Özellikler

- 🤖 Yapay zeka ile otomatik soru üretimi
- 📚 Ders ve konu bazlı soru üretimi
- ⚡ Anında test oluşturma ve başlatma
- 🎯 Zorluk seviyesi ayarlama
- ⏱️ Özelleştirilebilir süre ve soru sayısı

## Sistem Gereksinimleri

### AI Servisi
- **Port**: 8000
- **Endpoint**: `/generate_questions`
- **Protokol**: HTTP POST
- **Format**: JSON

### AI Servis API Formatı

#### Request
```json
{
    "subject": "Matematik",
    "topic": "Geometri",
    "difficulty": "medium",
    "question_count": 20,
    "question_type": "multiple_choice"
}
```

#### Response
```json
[
    {
        "question": "Bir üçgenin iç açıları toplamı kaç derecedir?",
        "options": ["90", "180", "270", "360"],
        "correct_answer": "180",
        "explanation": "Bir üçgenin iç açıları toplamı her zaman 180 derecedir."
    }
]
```

## Kurulum

### 1. AI Servisini Başlatın
```bash
# localhost:8000 portunda AI servisini çalıştırın
python ai_service.py
```

### 2. Uygulamayı Başlatın
```bash
dotnet run
```

### 3. Tarayıcıda Test Edin
```
http://localhost:5000/User/Exams
```

## Kullanım

### 1. AI ile Test Oluşturma
1. "Yapay Zeka ile Test Oluştur" sekmesine tıklayın
2. Test adını girin
3. Ders seçin
4. Konu seçin
5. Soru sayısını belirleyin (5-50 arası)
6. Süreyi ayarlayın (10-180 dakika arası)
7. Zorluk seviyesini seçin
8. "Test Oluştur" butonuna tıklayın

### 2. Test Başlatma
- Test oluşturulduktan sonra otomatik olarak sınava yönlendirilirsiniz
- Soruları cevaplayın
- Süre dolduğunda veya "Testi Bitir" butonuna tıkladığınızda test tamamlanır

## Teknik Detaylar

### Servis Katmanı
- `IAiQuestionService`: AI servis entegrasyonu için interface
- `AiQuestionService`: AI servis implementasyonu
- `ExamService`: Test oluşturma ve yönetimi

### Veri Transfer Objeleri
- `CustomExamCreateDto`: Test oluşturma parametreleri
- `AiQuestionResponse`: AI servisinden gelen yanıt

### Frontend
- `ai-exam.js`: AI test oluşturma JavaScript kodu
- `ai-exam.css`: AI test oluşturma stilleri
- Dinamik konu yükleme
- Form validasyonu
- Loading states

## Hata Yönetimi

### AI Servis Hataları
- Bağlantı hatası
- Servis yanıt vermiyor
- Geçersiz yanıt formatı

### Kullanıcı Hataları
- Eksik form alanları
- Geçersiz parametre değerleri
- Yetkilendirme hataları

## Güvenlik

- CSRF token koruması
- Kullanıcı yetkilendirmesi
- Input validasyonu
- SQL injection koruması

## Performans

- Asenkron AI servis çağrıları
- Veritabanı optimizasyonu
- Frontend caching
- Responsive tasarım

## Gelecek Geliştirmeler

- [ ] Çoklu AI servis desteği
- [ ] Soru kalitesi değerlendirmesi
- [ ] Kullanıcı geri bildirimleri
- [ ] AI model eğitimi
- [ ] Çoklu dil desteği

## Sorun Giderme

### AI Servis Bağlantı Hatası
```
Hata: AI servisi ile iletişim kurulamadı. Lütfen tekrar deneyin.
```

**Çözüm:**
1. AI servisinin çalıştığından emin olun
2. Port 8000'in açık olduğunu kontrol edin
3. Firewall ayarlarını kontrol edin

### Test Oluşturma Hatası
```
Hata: AI servisinden yeterli sayıda soru üretilemedi.
```

**Çözüm:**
1. AI servisinin doğru parametreleri aldığını kontrol edin
2. Servis loglarını inceleyin
3. Parametre değerlerini kontrol edin

## Destek

Herhangi bir sorun yaşarsanız:
1. Log dosyalarını kontrol edin
2. AI servis durumunu kontrol edin
3. Tarayıcı konsol hatalarını inceleyin
4. Geliştirici ekibi ile iletişime geçin
