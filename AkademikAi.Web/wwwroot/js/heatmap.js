document.addEventListener('DOMContentLoaded', function () {
    const heatmapGrid = document.getElementById('heatmap-grid');
    const monthLabelsContainer = document.getElementById('month-labels-container');

    // Sabitler
    const TOTAL_DAYS = 365;
    const today = new Date();
    const monthNames = ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"];

    // Haritanın başlangıç tarihini hesapla (Bugünden 365 gün önce)
    const startDate = new Date();
    startDate.setDate(today.getDate() - TOTAL_DAYS);

    // Başlangıç gününü Pazar'a (haftanın ilk günü) ayarla
    // Bu, sütunların düzgün hizalanmasını sağlar
    const dayOfWeek = startDate.getDay(); // 0: Pazar, 1: Pazartesi, ...
    startDate.setDate(startDate.getDate() - dayOfWeek);

    let currentDate = new Date(startDate);
    let lastMonth = -1;
    let weekCount = 0;

    // Toplam gün sayısı kadar döngü oluştur
    // GitHub ~53 hafta gösterdiği için biraz daha fazla gün üretebiliriz
    for (let i = 0; i < TOTAL_DAYS + dayOfWeek + 7; i++) {
        // Ay etiketi ekleme mantığı
        const currentMonth = currentDate.getMonth();
        if (currentMonth !== lastMonth) {
            lastMonth = currentMonth;
            // Ayın ilk günü hangi haftaya denk geliyorsa oraya etiketi ekle
            const weekIndex = Math.floor(i / 7);

            const monthLabel = document.createElement('div');
            monthLabel.className = 'month-label';
            monthLabel.textContent = monthNames[currentMonth];
            // CSS değişkeni ile sütun başlangıcını ayarla
            monthLabel.style.gridColumnStart = weekIndex + 1;
            monthLabelsContainer.appendChild(monthLabel);
        }

        // Gün hücresini oluştur
        const dayCell = document.createElement('div');
        dayCell.className = 'heatmap-day';

        // Sadece son 365 günü renklendir, öncesini boş bırak
        if (currentDate <= today && (today.getTime() - currentDate.getTime()) / (1000 * 3600 * 24) <= TOTAL_DAYS) {
            // Rastgele bir aktivite seviyesi ata (gerçek verinizle değiştirebilirsiniz)
            const activityLevel = Math.floor(Math.random() * 5); // 0 ile 4 arası
            const questionCount = activityLevel > 0 ? Math.floor(Math.random() * (activityLevel * 15)) + 1 : 0;

            dayCell.classList.add(`level-${activityLevel}`);
            dayCell.title = `${questionCount} soru - ${currentDate.toLocaleDateString('tr-TR', { day: 'numeric', month: 'long', year: 'numeric' })}`;
        }

        heatmapGrid.appendChild(dayCell);

        // Bir sonraki güne geç
        currentDate.setDate(currentDate.getDate() + 1);
    }
});