#!/usr/bin/env python3
"""
AI Test Soru Üretim Servisi
Bu dosya, localhost:8080 portunda çalışan basit bir AI servis örneğidir.
"""

from flask import Flask, request, jsonify
from flask_cors import CORS
import random
import json
import google.generativeai as genai
import os

app = Flask(__name__)
CORS(app)  # Cross-origin resource sharing için

# Google AI (Gemini) API Konfigürasyonu
# API Key her istekle birlikte gelecek
GOOGLE_API_KEY = None

# Gemini modeli her istek için dinamik olarak oluşturulacak

# Örnek soru veritabanı
# TYT Standartlarına Uygun Soru Veritabanı
# Gerçek veritabanı ders/konu isimleri + TYT uyumlu sorular
SAMPLE_QUESTIONS = {
    "Matematik": {
        "Temel Kavramlar": {
            "easy": [
                {
                    "question": "2 + 3 × 4 işleminin sonucu nedir?",
                    "options": ["14", "20", "12", "18"],
                    "correct_answer": "14",
                    "explanation": "İşlem önceliği: Önce çarpma 3×4=12, sonra toplama 2+12=14"
                },
                {
                    "question": "(-5) + 8 işleminin sonucu nedir?",
                    "options": ["3", "-3", "13", "-13"],
                    "correct_answer": "3",
                    "explanation": "Negatif ve pozitif sayı toplamı: -5 + 8 = 3"
                }
            ],
            "medium": [
                {
                    "question": "√25 + 3² işleminin sonucu nedir?",
                    "options": ["14", "16", "12", "18"],
                    "correct_answer": "14",
                    "explanation": "√25 = 5, 3² = 9, toplam: 5 + 9 = 14"
                }
            ],
            "hard": [
                {
                    "question": "2⁴ × 3² ÷ 6 işleminin sonucu nedir?",
                    "options": ["24", "32", "18", "12"],
                    "correct_answer": "24",
                    "explanation": "2⁴ = 16, 3² = 9, 16 × 9 ÷ 6 = 144 ÷ 6 = 24"
                }
            ]
        },
        "Sayı Basamakları": {
            "easy": [
                {
                    "question": "2457 sayısının yüzler basamağındaki rakam nedir?",
                    "options": ["2", "4", "5", "7"],
                    "correct_answer": "4",
                    "explanation": "2457 sayısında yüzler basamağı 4'tür"
                }
            ],
            "medium": [
                {
                    "question": "Üç basamaklı en küçük çift sayı nedir?",
                    "options": ["100", "102", "110", "200"],
                    "correct_answer": "100",
                    "explanation": "Üç basamaklı en küçük sayı 100 ve çifttir"
                }
            ]
        },
        "Bölme ve Bölünebilme": {
            "easy": [
                {
                    "question": "84 ÷ 7 işleminin sonucu nedir?",
                    "options": ["11", "12", "13", "14"],
                    "correct_answer": "12",
                    "explanation": "84 ÷ 7 = 12"
                }
            ],
            "medium": [
                {
                    "question": "Bir sayı hem 2'ye hem 3'e bölünebiliyorsa hangi sayıya da bölünür?",
                    "options": ["5", "6", "8", "9"],
                    "correct_answer": "6",
                    "explanation": "2 ve 3'ün EKOK'u 6'dır"
                }
            ]
        },
        "Rasyonel Sayılar": {
            "easy": [
                {
                    "question": "1/2 + 1/4 işleminin sonucu nedir?",
                    "options": ["2/6", "3/4", "1/3", "2/4"],
                    "correct_answer": "3/4",
                    "explanation": "2/4 + 1/4 = 3/4"
                }
            ],
            "medium": [
                {
                    "question": "0,25 kesrinin en sade hali nedir?",
                    "options": ["1/4", "25/100", "1/3", "2/8"],
                    "correct_answer": "1/4",
                    "explanation": "0,25 = 25/100 = 1/4"
                }
            ]
        },
        "Problemler": {
            "easy": [
                {
                    "question": "Bir kutuda 24 kalem var. 1/3'ü kırmızı ise kaç tane kırmızı kalem vardır?",
                    "options": ["6", "8", "9", "12"],
                    "correct_answer": "8",
                    "explanation": "24 × 1/3 = 8"
                }
            ],
            "medium": [
                {
                    "question": "Yaşları toplamı 45 olan iki kardeşten büyüğü küçüğünden 5 yaş büyüktür. Büyük kardeş kaç yaşında?",
                    "options": ["20", "22", "25", "30"],
                    "correct_answer": "25",
                    "explanation": "x + (x+5) = 45, 2x = 40, x = 20, büyük kardeş 25 yaşında"
                }
            ]
        },
        "Sayılar ve İşlemler": {
            "easy": [
                {
                    "question": "(-3) + 5 - (-2) işleminin sonucu nedir?",
                    "options": ["4", "6", "0", "-6"],
                    "correct_answer": "4",
                    "explanation": "(-3) + 5 - (-2) = -3 + 5 + 2 = 4"
                },
                {
                    "question": "2³ × 2² işleminin sonucu nedir?",
                    "options": ["2⁵", "2⁶", "4⁵", "8²"],
                    "correct_answer": "2⁵",
                    "explanation": "Aynı tabanlı üslü sayıların çarpımında üsler toplanır: 2³ × 2² = 2⁵"
                },
                {
                    "question": "36'nın karekökü kaçtır?",
                    "options": ["4", "6", "8", "9"],
                    "correct_answer": "6",
                    "explanation": "√36 = 6 çünkü 6² = 36"
                }
            ],
            "medium": [
                {
                    "question": "√72 ifadesinin en sade hali nedir?",
                    "options": ["6√2", "3√8", "2√18", "4√3"],
                    "correct_answer": "6√2",
                    "explanation": "√72 = √(36×2) = 6√2"
                },
                {
                    "question": "3⁻² + 2⁻¹ işleminin sonucu nedir?",
                    "options": ["5/9", "7/18", "5/6", "1/6"],
                    "correct_answer": "7/18",
                    "explanation": "3⁻² = 1/9, 2⁻¹ = 1/2, toplam = 1/9 + 1/2 = 2/18 + 9/18 = 11/18... 1/9 + 1/2 = 2+9/18 = 7/18"
                }
            ],
            "hard": [
                {
                    "question": "(2/3)⁻² + (1/4)⁻¹ işleminin sonucu nedir?",
                    "options": ["25/4", "13/4", "17/4", "21/4"],
                    "correct_answer": "25/4",
                    "explanation": "(2/3)⁻² = 9/4, (1/4)⁻¹ = 4, toplam = 9/4 + 16/4 = 25/4"
                }
            ]
        },
        "Cebirsel İfadeler": {
            "easy": [
                {
                    "question": "2x + 3 = 11 denkleminde x kaçtır?",
                    "options": ["2", "3", "4", "5"],
                    "correct_answer": "4",
                    "explanation": "2x + 3 = 11 → 2x = 8 → x = 4"
                },
                {
                    "question": "3(x - 2) = 15 denkleminde x kaçtır?",
                    "options": ["5", "6", "7", "8"],
                    "correct_answer": "7",
                    "explanation": "3(x - 2) = 15 → x - 2 = 5 → x = 7"
                }
            ],
            "medium": [
                {
                    "question": "x² - 5x + 6 = 0 denkleminin köklerinden biri 2 ise diğeri kaçtır?",
                    "options": ["1", "2", "3", "4"],
                    "correct_answer": "3",
                    "explanation": "Vieta: köklerin toplamı = 5, biri 2 ise diğeri 3"
                },
                {
                    "question": "(x + 3)² - (x - 1)² ifadesinin sadeleşmiş hali nedir?",
                    "options": ["8x + 8", "8x + 10", "4x + 8", "2x + 10"],
                    "correct_answer": "8x + 8",
                    "explanation": "(x+3)² - (x-1)² = (x²+6x+9) - (x²-2x+1) = 8x + 8"
                }
            ],
            "hard": [
                {
                    "question": "x² - 7x + 12 > 0 eşitsizliğinin çözüm kümesi nedir?",
                    "options": ["(-∞,3) ∪ (4,∞)", "(-∞,4) ∪ (3,∞)", "(3,4)", "(-3,4)"],
                    "correct_answer": "(-∞,3) ∪ (4,∞)",
                    "explanation": "x² - 7x + 12 = (x-3)(x-4), pozitif olması için x<3 veya x>4"
                }
            ]
        },
        "Geometri": {
            "easy": [
                {
                    "question": "Eşkenar üçgenin her bir iç açısı kaç derecedir?",
                    "options": ["45°", "60°", "90°", "120°"],
                    "correct_answer": "60°",
                    "explanation": "Eşkenar üçgende üç açı eşit: 180°/3 = 60°"
                },
                {
                    "question": "Kenar uzunluğu 5 cm olan karenin alanı kaç cm²'dir?",
                    "options": ["20", "25", "30", "35"],
                    "correct_answer": "25",
                    "explanation": "Kare alan = kenar² = 5² = 25 cm²"
                },
                {
                    "question": "Yarıçapı 3 cm olan dairenin çevresi kaç cm'dir? (π=3 alınız)",
                    "options": ["9", "18", "27", "36"],
                    "correct_answer": "18",
                    "explanation": "Daire çevresi = 2πr = 2×3×3 = 18 cm"
                }
            ],
            "medium": [
                {
                    "question": "Kenarları 3, 4, 5 cm olan üçgenin alanı kaç cm²'dir?",
                    "options": ["6", "7.5", "12", "15"],
                    "correct_answer": "6",
                    "explanation": "3-4-5 dik üçgen, alan = (3×4)/2 = 6 cm²"
                },
                {
                    "question": "Dikdörtgenin çevresi 24 cm, eni boyunun yarısı ise alanı kaç cm²'dir?",
                    "options": ["32", "36", "40", "48"],
                    "correct_answer": "32",
                    "explanation": "En=x, boy=2x, çevre: 6x=24, x=4. Alan=4×8=32 cm²"
                }
            ],
            "hard": [
                {
                    "question": "ABC üçgeninde |AB|=6, |AC|=8, ∠BAC=90° ise BC kenarına ait yükseklik kaçtır?",
                    "options": ["4.8", "5.2", "5.6", "6.0"],
                    "correct_answer": "4.8",
                    "explanation": "|BC|=10 (Pisagor), Alan=24, yükseklik=2×24/10=4.8"
                }
            ]
        },
        "Fonksiyonlar": {
            "easy": [
                {
                    "question": "f(x) = 2x + 1 fonksiyonu için f(3) değeri nedir?",
                    "options": ["5", "6", "7", "8"],
                    "correct_answer": "7",
                    "explanation": "f(3) = 2(3) + 1 = 6 + 1 = 7"
                },
                {
                    "question": "y = x + 2 doğrusunun y-keseni nedir?",
                    "options": ["(0,1)", "(0,2)", "(2,0)", "(-2,0)"],
                    "correct_answer": "(0,2)",
                    "explanation": "x=0 için y=2, y-keseni (0,2)"
                }
            ],
            "medium": [
                {
                    "question": "f(x) = x² - 4 fonksiyonunun sıfırları nelerdir?",
                    "options": ["±1", "±2", "±3", "±4"],
                    "correct_answer": "±2",
                    "explanation": "x² - 4 = 0 → x² = 4 → x = ±2"
                }
            ]
        }
    },
    "Türkçe": {
        "Sözcük Bilgisi": {
            "easy": [
                {
                    "question": "'Müteakip' kelimesinin anlamı nedir?",
                    "options": ["Önceki", "Sonraki", "Aynı zamandaki", "Karşıt"],
                    "correct_answer": "Sonraki",
                    "explanation": "Müteakip kelimesi 'sonraki, ardından gelen' anlamındadır."
                },
                {
                    "question": "'Müstakil' kelimesinin anlamı nedir?",
                    "options": ["Bağımlı", "Bağımsız", "Benzer", "Farklı"],
                    "correct_answer": "Bağımsız",
                    "explanation": "Müstakil 'bağımsız, tek başına' anlamındadır."
                }
            ],
            "medium": [
                {
                    "question": "'Tensip etmek' deyiminin anlamı nedir?",
                    "options": ["Reddetmek", "Onaylamak", "Ertelemek", "Unutmak"],
                    "correct_answer": "Onaylamak",
                    "explanation": "Tensip etmek 'uygun görmek, onaylamak' anlamındadır."
                }
            ]
        },
        "Cümle Bilgisi": {
            "easy": [
                {
                    "question": "'Kitabı masaya koydu.' cümlesinde 'masaya' kelimesi hangi görevdedir?",
                    "options": ["Özne", "Nesne", "Yer tamlayıcısı", "Zaman tamlayıcısı"],
                    "correct_answer": "Yer tamlayıcısı",
                    "explanation": "'Masaya' nereye sorusuna cevap veren yer tamlayıcısıdır."
                },
                {
                    "question": "'Ali okula gitti.' cümlesinde özne nedir?",
                    "options": ["Ali", "okula", "gitti", "Ali okula"],
                    "correct_answer": "Ali",
                    "explanation": "Eylemi yapan 'Ali' öznedir."
                }
            ],
            "medium": [
                {
                    "question": "Aşağıdaki cümlede yer alan birleşik çekimin türü nedir? 'Kitabı okuyagelmişti.'",
                    "options": ["Hikaye", "Rivayet", "Şart", "Istek"],
                    "correct_answer": "Rivayet",
                    "explanation": "'-miş + -ti' ekinin birleşimi rivayet birleşik çekimidir."
                }
            ]
        },
        "Paragraf": {
            "easy": [
                {
                    "question": "Bir paragrafın en önemli özelliği nedir?",
                    "options": ["Uzun olması", "Kısa olması", "Ana fikir birliği", "Çok örnekli olması"],
                    "correct_answer": "Ana fikir birliği",
                    "explanation": "Paragraf tek bir ana fikir etrafında oluşturulur."
                }
            ]
        }
    },
    "Fizik": {
        "Fizik Bilimine Giriş": {
            "easy": [
                {
                    "question": "Fizikte kullanılan temel büyüklüklerden hangisi uzunluk ölçer?",
                    "options": ["Metre", "Kilogram", "Saniye", "Kelvin"],
                    "correct_answer": "Metre",
                    "explanation": "Metre (m) uzunluk ölçü birimidir"
                },
                {
                    "question": "Skaler büyüklük hangisidir?",
                    "options": ["Hız", "Kuvvet", "Kütle", "İvme"],
                    "correct_answer": "Kütle",
                    "explanation": "Kütle sadece büyüklüğe sahip skaler bir büyüklüktür"
                }
            ],
            "medium": [
                {
                    "question": "Vektörel büyüklükler hangi özelliğe sahiptir?",
                    "options": ["Sadece büyüklük", "Büyüklük ve yön", "Sadece yön", "Hiçbiri"],
                    "correct_answer": "Büyüklük ve yön",
                    "explanation": "Vektörel büyüklükler hem büyüklük hem de yön bilgisi içerir"
                }
            ]
        },
        "Madde ve Özellikleri": {
            "easy": [
                {
                    "question": "Maddenin kütlesi hangi durumda değişir?",
                    "options": ["Yer değiştirince", "Isıtıldığında", "Basınç altında", "Hiçbir durumda"],
                    "correct_answer": "Hiçbir durumda",
                    "explanation": "Kütle maddenin değişmez özelliğidir"
                }
            ],
            "medium": [
                {
                    "question": "Özkütle (yoğunluk) formülü nedir?",
                    "options": ["m/V", "V/m", "m×V", "m+V"],
                    "correct_answer": "m/V",
                    "explanation": "Özkütle = kütle/hacim = m/V"
                }
            ]
        },
        "Kuvvet ve Hareket": {
            "easy": [
                {
                    "question": "Newton'un 1. yasası hangisidir?",
                    "options": ["F=ma", "Eylemsizlik", "Etki-tepki", "Kütle çekim"],
                    "correct_answer": "Eylemsizlik",
                    "explanation": "Newton'un 1. yasası eylemsizlik yasasıdır"
                },
                {
                    "question": "Düzgün doğrusal hareketin özelliği nedir?",
                    "options": ["Hız değişir", "İvme sıfırdır", "Yön değişir", "Hızlanır"],
                    "correct_answer": "İvme sıfırdır",
                    "explanation": "Düzgün doğrusal harekette hız sabittir, ivme sıfırdır"
                }
            ],
            "medium": [
                {
                    "question": "5 kg kütleli cismi 2 m/s² ivmeyle hareket ettiren kuvvet kaç N'dur?",
                    "options": ["7 N", "10 N", "3 N", "2.5 N"],
                    "correct_answer": "10 N",
                    "explanation": "F = ma = 5 × 2 = 10 N"
                }
            ]
        },
        "İş, Güç ve Enerji": {
            "easy": [
                {
                    "question": "İş birimi nedir?",
                    "options": ["Newton", "Watt", "Joule", "Kilogram"],
                    "correct_answer": "Joule",
                    "explanation": "İş birimi Joule (J)'dur"
                }
            ],
            "medium": [
                {
                    "question": "10 N kuvvetle 5 m yol alındığında yapılan iş kaç J'dur?",
                    "options": ["50 J", "15 J", "2 J", "5 J"],
                    "correct_answer": "50 J",
                    "explanation": "İş = Kuvvet × Yol = 10 × 5 = 50 J"
                }
            ]
        },
        "Elektrostatik": {
            "easy": [
                {
                    "question": "Elektrik yükü birimi nedir?",
                    "options": ["Coulomb", "Volt", "Amper", "Ohm"],
                    "correct_answer": "Coulomb",
                    "explanation": "Elektrik yükü birimi Coulomb (C)'dur"
                }
            ]
        }
    },
    "Kimya": {
        "Kimya Bilimi": {
            "easy": [
                {
                    "question": "Kimyada en küçük madde parçacığı nedir?",
                    "options": ["Molekül", "Atom", "Elektron", "Proton"],
                    "correct_answer": "Atom",
                    "explanation": "Atom kimyasal özellikleri koruyan en küçük parçacıktır"
                }
            ]
        },
        "Atom ve Periyodik Sistem": {
            "easy": [
                {
                    "question": "Atomun merkezinde hangi parçacıklar bulunur?",
                    "options": ["Elektron", "Proton ve Nötron", "Sadece Proton", "Sadece Nötron"],
                    "correct_answer": "Proton ve Nötron",
                    "explanation": "Atom çekirdeğinde proton ve nötronlar bulunur"
                },
                {
                    "question": "Hidrojenin periyodik tablodaki atom numarası kaçtır?",
                    "options": ["1", "2", "3", "4"],
                    "correct_answer": "1",
                    "explanation": "Hidrojen en basit element olup atom numarası 1'dir"
                }
            ],
            "medium": [
                {
                    "question": "Periyodik tabloda aynı grupta bulunan elementlerin ortak özelliği nedir?",
                    "options": ["Kütle", "Valens elektron sayısı", "Nötron sayısı", "Atom yarıçapı"],
                    "correct_answer": "Valens elektron sayısı",
                    "explanation": "Aynı gruptaki elementlerin valens elektron sayısı aynıdır"
                }
            ]
        },
        "Kimyasal Türler Arası Etkileşimler": {
            "easy": [
                {
                    "question": "NaCl bileşiğindeki bağ türü nedir?",
                    "options": ["İyonik", "Kovalent", "Metalik", "Hidrojen"],
                    "correct_answer": "İyonik",
                    "explanation": "Na ve Cl arasında elektron transferiyle iyonik bağ oluşur"
                }
            ]
        },
        "Maddenin Halleri": {
            "easy": [
                {
                    "question": "Suyun kaynama noktası kaç derecedir?",
                    "options": ["90°C", "100°C", "110°C", "120°C"],
                    "correct_answer": "100°C",
                    "explanation": "Su 1 atm basınçta 100°C'de kaynar"
                }
            ]
        },
        "Asitler, Bazlar ve Tuzlar": {
            "easy": [
                {
                    "question": "Asitlerin ortak özelliği nedir?",
                    "options": ["H⁺ iyonu verir", "OH⁻ iyonu verir", "Nötr olur", "Tuz oluşturur"],
                    "correct_answer": "H⁺ iyonu verir",
                    "explanation": "Asitler suda çözündüğünde H⁺ iyonu verir"
                }
            ]
        }
    },
    "Biyoloji": {
        "Yaşam Bilimi Biyoloji": {
            "easy": [
                {
                    "question": "Biyoloji bilimi neyi inceler?",
                    "options": ["Canlıları", "Mineralleri", "Gökleri", "Atomları"],
                    "correct_answer": "Canlıları",
                    "explanation": "Biyoloji canlıları ve yaşam süreçlerini inceleyen bilimdir"
                }
            ]
        },
        "Hücre": {
            "easy": [
                {
                    "question": "Hücre nedir?",
                    "options": ["Yaşamın temel birimi", "Atom", "Molekül", "Doku"],
                    "correct_answer": "Yaşamın temel birimi",
                    "explanation": "Hücre tüm canlıların yaşamsal temel birimidir"
                },
                {
                    "question": "Fotosentez hangi organellerde gerçekleşir?",
                    "options": ["Mitokondri", "Kloroplast", "Ribozom", "Golgi"],
                    "correct_answer": "Kloroplast",
                    "explanation": "Fotosentez klorofil içeren kloroplastlarda gerçekleşir"
                }
            ]
        },
        "Canlıların Sınıflandırılması": {
            "easy": [
                {
                    "question": "Canlıların bilimsel sınıflandırmasında en küçük birim nedir?",
                    "options": ["Tür", "Cins", "Familya", "Takım"],
                    "correct_answer": "Tür",
                    "explanation": "Taksonomi hiyerarşisinde en küçük birim türdür"
                }
            ]
        },
        "Hücre Bölünmeleri": {
            "easy": [
                {
                    "question": "Mitoz bölünme sonucu oluşan hücre sayısı kaçtır?",
                    "options": ["1", "2", "3", "4"],
                    "correct_answer": "2",
                    "explanation": "Mitoz sonucu 1 ana hücreden 2 yeni hücre oluşur"
                }
            ]
        },
        "Kalıtım": {
            "easy": [
                {
                    "question": "DNA'nın tam adı nedir?",
                    "options": ["Deoksiriboz Nükleik Asit", "Dezoksiribonükleik Asit", "Deoksi Nuklear Asit", "Dioksit Nükleik Asit"],
                    "correct_answer": "Dezoksiribonükleik Asit",
                    "explanation": "DNA = Dezoksiribonükleik Asit (Deoxyribonucleic Acid)"
                }
            ]
        }
    },
    "Fen Bilimleri": {
        "Fizik": {
            "easy": [
                {
                    "question": "Düzgün doğrusal hareketin özelliği nedir?",
                    "options": ["Hız değişir", "İvme sıfırdır", "Yön değişir", "Hızlanır"],
                    "correct_answer": "İvme sıfırdır",
                    "explanation": "Düzgün doğrusal harekette hız sabittir, ivme sıfırdır."
                },
                {
                    "question": "Ağırlığın birimi nedir?",
                    "options": ["kg", "N", "m/s²", "J"],
                    "correct_answer": "N",
                    "explanation": "Ağırlık bir kuvvet olduğu için birimi Newton (N)'dur."
                }
            ],
            "medium": [
                {
                    "question": "Serbest düşmede cismin ilk hızı sıfır ise 2 saniye sonra hızı kaç m/s olur? (g=10 m/s²)",
                    "options": ["10", "15", "20", "25"],
                    "correct_answer": "20",
                    "explanation": "v = gt = 10 × 2 = 20 m/s"
                }
            ]
        },
        "Kimya": {
            "easy": [
                {
                    "question": "Suyun kimyasal formülü nedir?",
                    "options": ["H₂O", "HO₂", "H₃O", "H₂O₂"],
                    "correct_answer": "H₂O",
                    "explanation": "Su molekülü 2 hidrojen ve 1 oksijen atomundan oluşur."
                },
                {
                    "question": "Periyodik tabloda element sayısı kaçtır?",
                    "options": ["108", "112", "116", "118"],
                    "correct_answer": "118",
                    "explanation": "Güncel periyodik tabloda 118 element vardır."
                }
            ],
            "medium": [
                {
                    "question": "NaCl bileşiğindeki bağ türü nedir?",
                    "options": ["İyonik", "Kovalent", "Metalik", "Hidrojen"],
                    "correct_answer": "İyonik",
                    "explanation": "Na ve Cl arasında elektron transferiyle iyonik bağ oluşur."
                }
            ]
        },
        "Biyoloji": {
            "easy": [
                {
                    "question": "Fotosentez hangi organellerde gerçekleşir?",
                    "options": ["Mitokondri", "Kloroplast", "Ribozom", "Golgi"],
                    "correct_answer": "Kloroplast",
                    "explanation": "Fotosentez klorofil içeren kloroplastlarda gerçekleşir."
                },
                {
                    "question": "DNA'nın tam adı nedir?",
                    "options": ["Deoksiriboz Nükleik Asit", "Dezoksiribonükleik Asit", "Deoksi Nuklear Asit", "Dioksit Nükleik Asit"],
                    "correct_answer": "Dezoksiribonükleik Asit",
                    "explanation": "DNA = Dezoksiribonükleik Asit (Deoxyribonucleic Acid)"
                }
            ]
        }
    },
    "Sosyal Bilimler": {
        "Tarih": {
            "easy": [
                {
                    "question": "Türkiye Cumhuriyeti hangi yıl kurulmuştur?",
                    "options": ["1920", "1921", "1922", "1923"],
                    "correct_answer": "1923",
                    "explanation": "Türkiye Cumhuriyeti 29 Ekim 1923'te ilan edilmiştir."
                },
                {
                    "question": "Osmanlı Devleti hangi yıl kurulmuştur?",
                    "options": ["1299", "1326", "1354", "1389"],
                    "correct_answer": "1299",
                    "explanation": "Osmanlı Devleti 1299 yılında Osman Bey tarafından kurulmuştur."
                }
            ],
            "medium": [
                {
                    "question": "I. Dünya Savaşı hangi yıllar arasında yaşanmıştır?",
                    "options": ["1912-1913", "1914-1918", "1919-1922", "1939-1945"],
                    "correct_answer": "1914-1918",
                    "explanation": "I. Dünya Savaşı 1914-1918 yılları arasında yaşanmıştır."
                }
            ]
        },
        "Coğrafya": {
            "easy": [
                {
                    "question": "Türkiye kaç kıtada yer alır?",
                    "options": ["1", "2", "3", "4"],
                    "correct_answer": "2",
                    "explanation": "Türkiye Avrupa ve Asya kıtalarında yer alır."
                },
                {
                    "question": "Dünya'nın en büyük okyanusu hangisidir?",
                    "options": ["Atlantik", "Hint", "Pasifik", "Arktik"],
                    "correct_answer": "Pasifik",
                    "explanation": "Pasifik Okyanusu dünya'nın en büyük okyanusudur."
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
    
    # Rastgele soru seçimi - her defasında farklı olsun
    import time
    random.seed(int(time.time() * 1000) % 10000)  # Mikrosaniye bazlı seed
    
    # Eğer yeterli soru yoksa, mevcut olanları tekrarla ve çoğalt
    if len(available_questions) < question_count:
        selected_questions = []
        
        # Önce mevcut soruları karıştır
        shuffled_questions = available_questions.copy()
        random.shuffle(shuffled_questions)
        
        for i in range(question_count):
            # Döngüsel olarak soruları kullan ama rastgele sırada
            base_question = shuffled_questions[i % len(shuffled_questions)]
            
            # Her soru için varyasyon ekle ve sıra numarası ekle
            variations = [
                f"Soru {i+1}: {base_question['question']}",
                f"{i+1}. {base_question['question']}",
                f"[{i+1}] {base_question['question']}",
                base_question['question']  # Bazıları orijinal kalsın
            ]
            
            selected_variation = random.choice(variations)
            
            modified_question = {
                "question": selected_variation,
                "options": base_question["options"].copy(),
                "correct_answer": base_question["correct_answer"],
                "explanation": base_question["explanation"]
            }
            
            # Seçenekleri de karıştır (doğru cevabı takip ederek)
            correct_answer = base_question["correct_answer"]
            options_copy = base_question["options"].copy()
            random.shuffle(options_copy)
            
            modified_question["options"] = options_copy
            modified_question["correct_answer"] = correct_answer  # Doğru cevap aynı kalır
            
            selected_questions.append(modified_question)
        
        return selected_questions
    
    # Yeterli soru varsa rastgele seç
    selected_questions = random.sample(available_questions, question_count)
    
    # Seçilen soruları da karıştır
    for question in selected_questions:
        correct_answer = question["correct_answer"]
        options_copy = question["options"].copy()
        random.shuffle(options_copy)
        question["options"] = options_copy
        question["correct_answer"] = correct_answer
    
    return selected_questions

def generate_ai_questions(subject, topic, difficulty, question_count):
    """AI benzeri soru üretimi - Esnek eşleştirme ile"""
    
    # Ders isimlerini normalize et (büyük/küçük harf, Türkçe karakter)
    subject_normalized = normalize_text(subject)
    topic_normalized = normalize_text(topic)
    
    print(f"[DEBUG] Gelen istek - Ders: '{subject}' -> '{subject_normalized}', Konu: '{topic}' -> '{topic_normalized}'")
    
    # Esnek eşleştirme yap
    matched_subject = find_best_match(subject_normalized, SAMPLE_QUESTIONS.keys())
    if not matched_subject:
        print(f"[DEBUG] Ders bulunamadı: '{subject}' (normalized: '{subject_normalized}')")
        return generate_fallback_questions(subject, topic, difficulty, question_count)
    
    matched_topic = find_best_match(topic_normalized, SAMPLE_QUESTIONS[matched_subject].keys())
    if not matched_topic:
        print(f"[DEBUG] Konu bulunamadı: '{topic}' (normalized: '{topic_normalized}') in '{matched_subject}'")
        return generate_fallback_questions(subject, topic, difficulty, question_count)
    
    print(f"[DEBUG] Eşleşme bulundu - Ders: '{matched_subject}', Konu: '{matched_topic}'")
    
    # Mevcut sorulardan seç
    base_questions = generate_questions(matched_subject, matched_topic, difficulty, question_count)
    
    if not base_questions:
        print(f"[DEBUG] Soru bulunamadı, fallback kullanılıyor")
        return generate_fallback_questions(subject, topic, difficulty, question_count)
    
    # TYT standartlarında AI sorular üret
    ai_questions = []
    for i, q in enumerate(base_questions):
        # TYT formatında soru metni düzenle
        question_text = q["question"]
        
        # TYT standart formatlarını uygula
        if "kaç" in question_text.lower() and not question_text.endswith("?"):
            question_text += "?"
        
        # TYT tarzı ifadeler ekle
        tyt_prefixes = [
            "Aşağıdakilerden hangisi",
            "Yukarıdaki bilgilere göre",
            "Verilen bilgilere göre",
            "Bu durumda"
        ]
        
        # TYT formatında düzenle
        if not any(prefix in question_text for prefix in tyt_prefixes):
            if "?" in question_text:
                # Soru zaten uygun formatta
                pass
            else:
                question_text = f"Verilen bilgilere göre, {question_text.lower()}"
        
        # TYT stillinde başlık ekle
        tyt_question = {
            "question": f"[TYT - Soru {i+1}] {question_text}",
            "options": q["options"],
            "correct_answer": q["correct_answer"],
            "explanation": f"TYT çözüm: {q['explanation']}"
        }
        ai_questions.append(tyt_question)
    
    return ai_questions

def normalize_text(text):
    """Metni normalize et (küçük harf, Türkçe karakter dönüşümü)"""
    if not text:
        return ""
    
    # Türkçe karakter dönüşümleri
    char_map = {
        'ç': 'c', 'ğ': 'g', 'ı': 'i', 'ö': 'o', 'ş': 's', 'ü': 'u',
        'Ç': 'c', 'Ğ': 'g', 'İ': 'i', 'Ö': 'o', 'Ş': 's', 'Ü': 'u'
    }
    
    result = text.lower().strip()
    for tr_char, en_char in char_map.items():
        result = result.replace(tr_char, en_char)
    
    return result

def find_best_match(target, options):
    """En iyi eşleşmeyi bul - güçlendirilmiş eşleştirme"""
    target_norm = normalize_text(target)
    
    # 1. Tam eşleşme
    for option in options:
        if normalize_text(option) == target_norm:
            return option
    
    # 2. Eş anlamlı kelime eşleştirmeleri
    subject_synonyms = {
        'matematik': ['math', 'matematik', 'mat'],
        'fizik': ['physics', 'fizik', 'fiz'],
        'kimya': ['chemistry', 'kimya', 'kim'],
        'biyoloji': ['biology', 'biyoloji', 'bio'],
        'turkce': ['turkish', 'türkçe', 'turkce', 'edebiyat'],
        'fen bilimleri': ['science', 'fen', 'fen bilimleri'],
        'sosyal bilimler': ['social', 'sosyal', 'tarih', 'cografya', 'coğrafya']
    }
    
    topic_synonyms = {
        'geometri': ['geometry', 'geometri', 'sekil', 'şekil'],
        'sayilar ve islemler': ['numbers', 'sayılar', 'islem', 'işlem', 'temel kavramlar'],
        'cebirsel ifadeler': ['algebra', 'cebir', 'denklem', 'problemler'],
        'fonksiyonlar': ['functions', 'fonksiyon'],
        'sozcuk bilgisi': ['vocabulary', 'kelime', 'sözcük', 'anlam'],
        'cumle bilgisi': ['grammar', 'dilbilgisi', 'cümle'],
        'temel kavramlar': ['basic', 'temel', 'kavram', 'sayılar ve işlemler'],
        'kuvvet ve hareket': ['force', 'motion', 'fizik bilimine giriş', 'mekanik'],
        'atom ve periyodik sistem': ['atom', 'periyodik', 'kimya bilimi'],
        'hucre': ['cell', 'hücre', 'yaşam bilimi biyoloji']
    }
    
    # Target için eş anlamlıları kontrol et
    target_synonyms = []
    for key, synonyms in {**subject_synonyms, **topic_synonyms}.items():
        if target_norm in synonyms:
            target_synonyms.extend(synonyms)
            break
    
    if target_synonyms:
        for option in options:
            option_norm = normalize_text(option)
            if option_norm in target_synonyms:
                return option
    
    # 3. Kısmi eşleşme
    for option in options:
        option_norm = normalize_text(option)
        if target_norm in option_norm or option_norm in target_norm:
            return option
    
    # 4. Kelime bazlı eşleşme
    target_words = target_norm.split()
    for option in options:
        option_norm = normalize_text(option)
        option_words = option_norm.split()
        
        # En az bir kelime ortak ise
        common_words = set(target_words) & set(option_words)
        if common_words:
            return option
    
    return None

def generate_fallback_questions(subject, topic, difficulty, question_count):
    """TYT standartlarında eşleşme bulunamadığında genel sorular üret"""
    
    # TYT stillinde soru şablonları
    tyt_templates = {
        "Matematik": [
            {
                "question": f"{topic} konusunda: 2x + 3 = 7 türünde denklemde x değeri nasıl bulunur?",
                "options": ["x = 2", "x = 3", "x = 4", "x = 5"],
                "correct_answer": "x = 2",
                "explanation": f"TYT Matematik'te {topic} konusunda temel işlem adımlarını takip etmeliyiz."
            },
            {
                "question": f"{topic} konusundaki temel kavram hangisidir?",
                "options": ["Toplama", "Çıkarma", "Çarpma", "Bölme"],
                "correct_answer": "Toplama",
                "explanation": f"TYT'de {topic} konusu temel matematik işlemlerini kapsar."
            }
        ],
        "Türkçe": [
            {
                "question": f"{topic} konusunda: 'Evden okula gitti.' cümlesinde özne hangisidir?",
                "options": ["Ev", "Okul", "Gitti", "Örtülü özne"],
                "correct_answer": "Örtülü özne",
                "explanation": f"TYT Türkçe'de {topic} konusunda özne türlerini bilmek önemlidir."
            },
            {
                "question": f"{topic} konusundaki temel kural nedir?",
                "options": ["Büyük harf", "Noktalama", "Yazım", "Anlam"],
                "correct_answer": "Yazım",
                "explanation": f"TYT'de {topic} konusu Türkçe kurallarını kapsar."
            }
        ],
        "Fen Bilimleri": [
            {
                "question": f"{topic} konusunda: Newton'un birinci yasası hangisidir?",
                "options": ["F=ma", "Eylemsizlik", "Etki-tepki", "Çekim"],
                "correct_answer": "Eylemsizlik",
                "explanation": f"TYT Fen'de {topic} konusu temel fizik yasalarını kapsar."
            },
            {
                "question": f"{topic} konusundaki temel birim nedir?",
                "options": ["Meter", "Kilogram", "Saniye", "Newton"],
                "correct_answer": "Meter",
                "explanation": f"TYT'de {topic} konusu temel ölçü birimlerini kapsar."
            }
        ],
        "Sosyal Bilimler": [
            {
                "question": f"{topic} konusunda: Türkiye Cumhuriyeti hangi yıl kurulmuştur?",
                "options": ["1920", "1921", "1922", "1923"],
                "correct_answer": "1923",
                "explanation": f"TYT Sosyal'de {topic} konusu Türk tarihini kapsar."
            },
            {
                "question": f"{topic} konusundaki önemli olay nedir?",
                "options": ["Savaş", "Barış", "Antlaşma", "Kuruluş"],
                "correct_answer": "Kuruluş",
                "explanation": f"TYT'de {topic} konusu tarihsel olayları kapsar."
            }
        ]
    }
    
    # Ders kategorisini belirle
    subject_category = "Matematik"
    for category in tyt_templates.keys():
        if category.lower() in subject.lower():
            subject_category = category
            break
    
    # İlgili kategoriden şablonları al
    templates = tyt_templates.get(subject_category, tyt_templates["Matematik"])
    
    # İstenen sayıda TYT tipi soru üret
    generated_questions = []
    for i in range(question_count):
        template_index = i % len(templates)
        base_question = templates[template_index]
        
        # TYT formatında soru üret
        modified_question = {
            "question": f"[TYT {subject_category} - Soru {i+1}] " + base_question["question"],
            "options": base_question["options"].copy(),
            "correct_answer": base_question["correct_answer"],
            "explanation": f"TYT standardı: {base_question['explanation']}"
        }
        
        generated_questions.append(modified_question)
    
    return generated_questions

def generate_questions_with_real_ai(subject, topic, difficulty, question_count, google_api_key):
    """Gemini AI ile gerçek soru üretimi"""
    
    try:
        print(f"[GEMINI] API Key alındı: {google_api_key[:10]}...")
        
        # Google API Key'ini konfigüre et
        genai.configure(api_key=google_api_key)
        
        # Gemini modelini dinamik olarak oluştur
        model = genai.GenerativeModel('gemini-2.5-flash')
        # TYT seviyesine göre zorluk tanımı
        difficulty_map = {
            "easy": "kolay seviye, temel kavramları test eden",
            "medium": "orta seviye, kavramları ilişkilendiren", 
            "hard": "zor seviye, analitik düşünce gerektiren"
        }
        
        difficulty_text = difficulty_map.get(difficulty, "orta seviye")
        
        # Gemini için TYT prompt'u
        prompt = f"""
Sen TYT (Temel Yeterlilik Testi) soru hazırlama uzmanısın. 

GÖREV: {subject} dersi {topic} konusunda {difficulty_text} {question_count} adet çoktan seçmeli soru hazırla.

KURALLAR:
1. Her soru tam olarak 4 seçenek (A, B, C, D) olmalı
2. Sadece 1 doğru cevap olmalı
3. TYT formatında ve Türkçe olmalı
4. Güncel müfredata uygun olmalı
5. Seçenekler mantıklı ve aldatıcı olmalı
6. Açık ve anlaşılır dil kullan

ÇIKTI FORMATI (JSON):
{{
  "questions": [
    {{
      "question": "Soru metni burada",
      "options": ["A seçeneği", "B seçeneği", "C seçeneği", "D seçeneği"],
      "correct_answer": "Doğru seçenek metni",
      "explanation": "Doğru cevabın açıklaması"
    }}
  ]
}}

Lütfen {question_count} adet soru üret ve sadece JSON formatında yanıt ver.
"""

        print(f"[GEMINI] İstek gönderiliyor: {subject} - {topic} - {difficulty} - {question_count} soru")
        
        # Gemini'ye istek gönder
        response = model.generate_content(prompt)
        response_text = response.text
        
        print(f"[GEMINI] Ham yanıt alındı: {len(response_text)} karakter")
        
        # JSON'u parse et
        try:
            # JSON'u temizle (markdown kod bloklarını kaldır)
            if "```json" in response_text:
                json_start = response_text.find("```json") + 7
                json_end = response_text.find("```", json_start)
                response_text = response_text[json_start:json_end].strip()
            elif "```" in response_text:
                json_start = response_text.find("```") + 3
                json_end = response_text.find("```", json_start)
                response_text = response_text[json_start:json_end].strip()
            
            # JSON parse et
            ai_response = json.loads(response_text)
            questions = ai_response.get("questions", [])
            
            if not questions:
                print("[GEMINI] Hata: Boş soru listesi döndü")
                return generate_fallback_questions(subject, topic, difficulty, question_count)
            
            print(f"[GEMINI] Başarılı: {len(questions)} soru üretildi")
            
            # AI'dan gelen soruları formatla
            formatted_questions = []
            for i, q in enumerate(questions[:question_count]):  # İstenen sayıda soru al
                formatted_question = {
                    "question": f"[TYT AI - Soru {i+1}] {q.get('question', 'Soru metni bulunamadı')}",
                    "options": q.get('options', ['A', 'B', 'C', 'D']),
                    "correct_answer": q.get('correct_answer', q.get('options', ['A'])[0]),
                    "explanation": f"AI Çözüm: {q.get('explanation', 'Açıklama bulunamadı')}"
                }
                formatted_questions.append(formatted_question)
            
            return formatted_questions
            
        except json.JSONDecodeError as e:
            print(f"[GEMINI] JSON Parse Hatası: {e}")
            print(f"[GEMINI] Ham text: {response_text[:500]}...")
            return generate_fallback_questions(subject, topic, difficulty, question_count)
            
    except Exception as e:
        print(f"[GEMINI] Genel Hata: {e}")
        return generate_fallback_questions(subject, topic, difficulty, question_count)

@app.route('/generate_questions', methods=['POST'])
def generate_questions_endpoint():
    """Soru üretimi endpoint'i"""
    
    try:
        data = request.get_json()
        
        # Gerekli alanları kontrol et
        required_fields = ['subject', 'topic', 'difficulty', 'question_count', 'google_api_key']
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
        google_api_key = data['google_api_key']
        
        # Google API Key'ini doğrula
        if not google_api_key or len(google_api_key) < 10:
            return jsonify({
                'error': 'Geçerli bir Google API Key gerekli',
                'status': 'error'
            }), 400
            
        print(f"[ENDPOINT] Google API Key alındı: {google_api_key[:10]}...")
        
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
        
        # GERÇEK AI (Gemini) ile soruları üret
        print(f"[ENDPOINT] Gemini AI kullanılarak soru üretiliyor...")
        questions = generate_questions_with_real_ai(subject, topic, difficulty, question_count, google_api_key)
        
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
        'status': 'ok',
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
        },
        'available_subjects': list(SAMPLE_QUESTIONS.keys())
    })

if __name__ == '__main__':
    print("AI Test Soru Üretim Servisi başlatılıyor...")
    print("Port: 8081")
    print("URL: http://127.0.0.1:8081")
    print("GEMINI AI entegrasyonu aktif!")
    print("API Key: Her istekle configuration'dan alınacak")
    print("Kullanılabilir dersler:", list(SAMPLE_QUESTIONS.keys()))
    print("=" * 50)
    
    app.run(host='127.0.0.1', port=8081, debug=True)
