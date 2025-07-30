# AkademikAI Seed Data

Bu klasör, AkademikAI projesinin veritabanı seed data'larını içerir.

## İçerik

### DataSeeder.cs
Ana seed data sınıfı. Tüm entity'ler için örnek veriler oluşturur:

- **Users**: 5 kullanıcı (1 Admin, 1 Öğretmen, 3 Öğrenci)
- **Topics**: 6 ana konu + alt konular (Matematik, Fizik, Kimya, Biyoloji, Türkçe, Tarih)
- **Questions**: 10 örnek soru (Matematik, Fizik, Kimya konularından)
- **QuestionsOptions**: Her soru için 4 seçenek (A, B, C, D)
- **QuestionsTopic**: Soruların konularla ilişkilendirilmesi
- **UserAnswers**: Öğrencilerin rastgele cevapları
- **UserNotifications**: Öğrenciler için bildirimler
- **UserPerformanceSummaries**: Öğrenci performans özetleri
- **UserRecommendation**: Öğrenciler için öneriler

### DatabaseSeeder.cs
Veritabanı seed işlemlerini yöneten extension method'ları içerir.

## Kullanım

Seed data otomatik olarak uygulama başlangıcında çalışır. Eğer veritabanında hiç kullanıcı yoksa, seed data eklenir.

## Test Kullanıcıları

### Admin Kullanıcısı
- **Email**: admin@akademikai.com
- **Şifre**: Admin123!
- **Rol**: Admin

### Öğretmen Kullanıcısı
- **Email**: ogretmen@akademikai.com
- **Şifre**: Ogretmen123!
- **Rol**: Teacher

### Öğrenci Kullanıcıları
- **Email**: ahmet@akademikai.com
- **Şifre**: Ahmet123!
- **Rol**: Student

- **Email**: ayse@akademikai.com
- **Şifre**: Ayse123!
- **Rol**: Student

- **Email**: mehmet@akademikai.com
- **Şifre**: Mehmet123!
- **Rol**: Student

## Konular

### Ana Konular
1. **Matematik** - Alt konular: Temel Matematik, Cebir, Geometri, Trigonometri
2. **Fizik** - Alt konular: Mekanik, Elektrik, Optik
3. **Kimya** - Alt konular: (Henüz eklenmedi)
4. **Biyoloji** - Alt konular: (Henüz eklenmedi)
5. **Türkçe** - Alt konular: (Henüz eklenmedi)
6. **Tarih** - Alt konular: (Henüz eklenmedi)

## Sorular

Seed data'da 10 örnek soru bulunmaktadır:

### Matematik Soruları (5 adet)
1. 2x + 5 = 13 denkleminin çözümü nedir?
2. Bir üçgenin iç açıları toplamı kaç derecedir?
3. x² - 4x + 4 = 0 denkleminin çözümü nedir?
4. Bir dairenin alanı πr² formülü ile hesaplanır. Yarıçapı 5 cm olan dairenin alanı kaç cm²'dir?
5. sin(30°) değeri kaçtır?

### Fizik Soruları (3 adet)
1. Newton'un birinci yasası nedir?
2. F = ma formülünde F, m ve a neyi temsil eder?
3. Bir cismin kinetik enerjisi hangi formülle hesaplanır?

### Kimya Soruları (2 adet)
1. Suyun kimyasal formülü nedir?
2. pH değeri 7'den küçük olan çözeltiler nasıl adlandırılır?

## Notlar

- Tüm şifreler SHA256 ile hash'lenmiştir
- Sorular MEB kaynaklı olarak işaretlenmiştir
- Zorluk seviyeleri: easy, medium, hard, veryhard
- Tarihler dinamik olarak oluşturulur (son 30 gün içinde)
- Performans verileri rastgele oluşturulur 