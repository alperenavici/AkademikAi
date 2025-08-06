// heatmap.js - Geliştirilmiş ve Sağlamlaştırılmış Versiyon

document.addEventListener('DOMContentLoaded', function () {
    // 1. GEREKLİ ELEMENTLERİ VE VERİYİ SEÇ
    const grid = document.getElementById('heatmap-grid');
    const tooltip = document.getElementById('tooltip');
    const monthLabelsContainer = document.getElementById('month-labels-container');
    const activityData = window.heatmapData || [];

    if (!grid) {
        console.error('Heatmap grid elementi (#heatmap-grid) bulunamadı!');
        return;
    }

    // --- SAAT DİLİMİ SORUNUNU ÇÖZMEK İÇİN YARDIMCI FONKSİYON ---
    // Bir tarihi alıp saat, dakika, saniye ve milisaniyelerini sıfırlayarak
    // sadece Yıl-Ay-Gün olarak temsil eden bir UTC Date nesnesi döndürür.
    function getUtcDateKey(date) {
        return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getUTCDate()));
    }

    // YYYY-MM-DD formatında string anahtar döndüren fonksiyon
    function getDateString(date) {
        return date.toISOString().split('T')[0];
    }


    // 2. VERİYİ HIZLI ERİŞİM İÇİN BİR HARİTAYA (MAP) DÖNÜŞTÜR
    const activityMap = new Map();
    activityData.forEach(item => {
        const itemDate = new Date(item.date);
        const dateKey = getDateString(getUtcDateKey(itemDate));
        // DEĞİŞİKLİK: item.count yerine item.questionCount kullanıyoruz.
        activityMap.set(dateKey, item.questionCount);
    });


    // 3. RENK SKALASI FONKSİYONU (Değişiklik yok)
    function getColorClass(count) {
        if (!count || count === 0) return 'color-level-0';
        if (count >= 1 && count <= 5) return 'color-level-1';
        if (count >= 6 && count <= 10) return 'color-level-2';
        if (count >= 11 && count <= 20) return 'color-level-3';
        if (count > 20) return 'color-level-4';
        return 'color-level-0';
    }


    // 4. ISI HARİTASI IZGARASINI VE AY ETİKETLERİNİ OLUŞTUR
    // Grid'i ve ay etiketlerini temizle (sayfa yenilemelerinde tekrar eklenmemesi için)
    grid.innerHTML = '';
    monthLabelsContainer.innerHTML = '';

    const today = getUtcDateKey(new Date());
    const oneYearAgo = getUtcDateKey(new Date());
    oneYearAgo.setUTCFullYear(today.getUTCFullYear() - 1);
    oneYearAgo.setUTCDate(oneYearAgo.getUTCDate() + 1); // Tam 365 gün öncesi için ayarla

    // BAŞLANGIÇ GÜNÜ HESAPLAMASINI SAĞLAMLAŞTIRMA
    // JavaScript'te getDay() 0=Pazar, 6=Cumartesi. Bizim gridimiz Pazartesi başlıyor.
    // Pazar için 6, Pazartesi için 0 boşluk, Salı için 1 boşluk...
    let firstDayOfWeek = oneYearAgo.getUTCDay(); // 0=Pazar, 1=Pzt...
    let emptyCellsAtStart = (firstDayOfWeek === 0) ? 6 : firstDayOfWeek - 1; // Eğer Pazar ise 6, diğer günler için (gün-1) boşluk

    for (let i = 0; i < emptyCellsAtStart; i++) {
        grid.appendChild(document.createElement('div'));
    }

    const monthNames = ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"];
    let currentMonth = -1;

    for (let day = new Date(oneYearAgo); day <= today; day.setUTCDate(day.getUTCDate() + 1)) {
        const loopDate = getUtcDateKey(day);

        // Ay etiketlerini oluştur
        if (loopDate.getUTCMonth() !== currentMonth) {
            currentMonth = loopDate.getUTCMonth();
            // Ayın ilk günü veya ayın ilk haftası ise etiketi ekle
            if (loopDate.getUTCDate() <= 7) {
                const monthLabel = document.createElement('div');
                monthLabel.className = 'month-label';
                monthLabel.textContent = monthNames[currentMonth];
                monthLabelsContainer.appendChild(monthLabel);
            }
        }

        const dateKey = getDateString(loopDate);
        const count = activityMap.get(dateKey) || 0;

        const cell = document.createElement('div');
        cell.className = 'heatmap-cell';
        cell.classList.add(getColorClass(count));

        cell.dataset.date = dateKey;
        cell.dataset.count = count;

        // 5. TOOLTIP (İPUCU) İÇİN EVENT LISTENER'LARI EKLE
        cell.addEventListener('mouseover', (event) => {
            const cellData = event.target.dataset;
            if (cellData.count && parseInt(cellData.count, 10) > 0) {
                // Tooltip tarihi için saat dilimi dönüşümünü engelle
                const [year, month, day] = cellData.date.split('-').map(Number);
                const readableDate = new Date(year, month - 1, day).toLocaleDateString('tr-TR', {
                    year: 'numeric', month: 'long', day: 'numeric', timeZone: 'UTC'
                });

                tooltip.innerHTML = `<strong>${cellData.count} soru</strong><br>${readableDate}`;
                tooltip.style.display = 'block';
                tooltip.style.left = `${event.pageX + 10}px`;
                tooltip.style.top = `${event.pageY + 10}px`;
            }
        });

        cell.addEventListener('mouseout', () => {
            tooltip.style.display = 'none';
        });

        grid.appendChild(cell);
    }
});