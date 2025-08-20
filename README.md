# AkademikAi - AI Destekli TYT Sınav Sistemi

**AkademikAi**, öğrencilerin TYT (Temel Yeterlilik Testi) sınavına hazırlanmaları için geliştirilmiş modern bir web uygulamasıdır. Yapay zeka teknolojisi ile dinamik soru üretimi, kişiselleştirilmiş performans analizi ve kapsamlı sınav simülasyonu sunar.

## 🎯 Proje Hedefi

TYT sınavına hazırlanan öğrencilere:
- Gerçek sınav deneyimi yaşatmak
- AI ile sınırsız soru çeşitliliği sunmak
- Performanslarını detaylı analiz etmek
- Zayıf yönlerini belirleyip güçlendirmek

## ✨ Ana Özellikler

### 🤖 AI Destekli Soru Üretimi
- **Google Gemini API** ile gerçek zamanlı soru üretimi
- **DeepSeek API** fallback sistemi ile %99.9 uptime garantisi
- TYT ve AYT standartlarına uygun kaliteli sorular
- Konu ve zorluk seviyesine göre özelleştirilebilir sorular



### 📊 Detaylı Performans Analizi
- Sınav sonuçları ve istatistikler
- Konu bazlı başarı oranları
- Zaman yönetimi analizi
- İlerleme grafikleri

### 🎓 Kullanıcı Rolleri
- **Öğrenci**: Sınav çözme, performans takibi
- **Admin**: Sınav yönetimi, sistem kontrolü

## 🏗️ Teknoloji Stack

### Backend
- **ASP.NET Core 8.0** - Web API ve MVC
- **Entity Framework Core** - Veritabanı ORM
- **SQL Server** - Veritabanı
- **AutoMapper** - Nesne eşleme

### Frontend
- **HTML5 & CSS3** - Modern UI/UX
- **JavaScript (ES6+)** - Dinamik etkileşimler
- **Bootstrap** - Responsive tasarım

### AI Servisleri
- **Python Flask** - AI servis API
- **Google Gemini API** - Birincil AI soru üretimi
- **DeepSeek API** - Yedek AI sistemi

## 🚀 Kurulum

### Gereksinimler
- .NET 8.0 SDK
- SQL Server (LocalDB destekli)
- Python 3.8+
- Node.js (opsiyonel, frontend geliştirme için)

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/kullaniciadi/AkademikAi.git
cd AkademikAi
```

### 2. Veritabanını Kurun
```bash
cd AkademikAi.Data
dotnet ef database update
```

### 3. Bağımlılıkları Yükleyin
```bash
# .NET bağımlılıkları
dotnet restore

# Python bağımlılıkları
pip install -r requirements.txt
```

### 4. Yapılandırma
`AkademikAi.Web/appsettings.json` dosyasında API anahtarlarınızı güncelleyin:

```json
{
  "GoogleAI": {
    "ApiKey": "YOUR_GOOGLE_GEMINI_API_KEY",
    "BaseUrl": "http://127.0.0.1:8081"
  },
  "DeepSeekAI": {
    "ApiKey": "YOUR_DEEPSEEK_API_KEY",
    "BaseUrl": "https://api.deepseek.com/v1",
    "Model": "deepseek-chat"
  }
}
```

### 5. Uygulamayı Başlatın
```bash
# AI Servisini başlatın (Terminal 1)
python ai_service.py

# Web uygulamasını başlatın (Terminal 2)
cd AkademikAi.Web
dotnet run
```

Uygulama `https://localhost:5001` adresinde çalışacaktır.

## 📖 Kullanım Kılavuzu

### Öğrenci Olarak
1. **Kayıt Olun** ve hesabınızı doğrulayın
2. **Dashboard**'a gidin ve istatistiklerinizi inceleyin
3. **Yeni Sınav** oluşturun:
   - Dersi seçin (Matematik, Türkçe, vb.)
   - Konuyu belirleyin
   - Soru sayısı ve zorluk seviyesini ayarlayın
4. **AI ile Soru Üret** butonunu kullanarak dinamik sorular oluşturun
5. **Sınavı Başlatın** ve zamanında çözün
6. **Sonuçları** analiz edin ve eksik yönlerinizi belirleyin

### Admin Olarak
1. **Admin Paneli**'ne giriş yapın
2. **Sınav Yönetimi** bölümünden tüm sınavları görüntüleyin
3. **Kullanıcı İstatistiklerini** takip edin
4. **Sistem Logları**nı kontrol edin

## 🤖 AI Sistemi Nasıl Çalışır?

### Çift Güvenlik Sistemi
1. **Birincil**: Google Gemini API ile kaliteli soru üretimi
2. **Yedek**: DeepSeek API ile kesintisiz hizmet
3. **Son Çare**: Önceden hazırlanmış fallback sorular

### Soru Üretim Süreci
```
İstek → Gemini API → Başarılı? → Soru Döndür
                  ↓ Başarısız
                DeepSeek API → Başarılı? → Soru Döndür
                            ↓ Başarısız
                          Fallback Sorular → Soru Döndür
```

## 📊 Veritabanı Şeması

### Ana Tablolar
- **Users**: Kullanıcı bilgileri
- **Subjects**: Ders kategorileri
- **Topics**: Konu başlıkları
- **Questions**: Soru havuzu
- **Exams**: Sınav kayıtları
- **UserAnswers**: Kullanıcı cevapları
- **PerformanceSummaries**: Performans verileri

## 🛠️ Geliştirici Notları

### Proje Yapısı
```
AkademikAi/
├── AkademikAi.Core/          # DTOs ve Core modeller
├── AkademikAi.Data/          # Veritabanı katmanı
├── AkademikAi.Entity/        # Domain modelleri
├── AkademikAi.Service/       # İş mantığı katmanı
├── AkademikAi.Web/          # Web uygulaması
└── ai_service.py            # Python AI servisi
```

### Önemli Servisler
- **AiQuestionService**: AI ile soru üretimi
- **ExamService**: Sınav yönetimi
- **UserService**: Kullanıcı işlemleri
- **PerformanceService**: Performans analizi

### API Endpoints
- `POST /api/exam/create-custom-ai` - AI ile sınav oluştur
- `GET /api/performance/summary` - Performans özeti
- `POST /api/user/register` - Kullanıcı kaydı

## 🔧 Yapılandırma

### Ortam Değişkenleri
```env
GOOGLE_AI_API_KEY=your_gemini_api_key
DEEPSEEK_AI_API_KEY=your_deepseek_api_key
CONNECTION_STRING=your_database_connection
```

### AI Servisi Ayarları
- **Port**: 8081
- **Timeout**: 30 saniye
- **Max Tokens**: 2000
- **Temperature**: 0.7

## 🐛 Sorun Giderme

### Sık Karşılaşılan Sorunlar

**AI servisi bağlanamıyor**
```bash
# Servisin çalışıp çalışmadığını kontrol edin
netstat -an | findstr 8081

# Servisi yeniden başlatın
python ai_service.py
```

**Veritabanı hatası**
```bash
# Migration'ları güncelleyin
dotnet ef database update
```

**API anahtarı hatası**
- `appsettings.json` dosyasındaki API anahtarlarını kontrol edin
- Anahtarların geçerli ve aktif olduğundan emin olun

## 📈 Performans

- **Soru üretim süresi**: ~3-5 saniye
- **Sınav yükleme süresi**: <2 saniye
- **Eş zamanlı kullanıcı kapasitesi**: 100+
- **Veritabanı yanıt süresi**: <100ms

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

## 👥 Ekip

- **Lead Developer**: Alper Enavici
- **AI Specialist**: AI Integration Team
- **UI/UX Designer**: Frontend Team

## 📞 İletişim

- **Email**: a.avci.alperen@gmail.com
- **Website**: https://alperenavci.dev
- **GitHub**: https://github.com/alperenavici/AkademikAi


