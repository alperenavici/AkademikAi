document.addEventListener('DOMContentLoaded', function () {
    const heatmapGrid = document.getElementById('heatmap-grid');
    const monthLabelsContainer = document.getElementById('month-labels-container');

    // Sabitler
    const TOTAL_DAYS = 365;
    const today = new Date();
    const monthNames = ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"];

    // Renk skalası
    const colorScale = [
        { threshold: 0, color: "#EBEDF0" },
        { threshold: 1, color: "#9BE9A8" },
        { threshold: 5, color: "#40C463" },
        { threshold: 10, color: "#30A14E" },
        { threshold: 20, color: "#216E39" }
    ];

    function getColor(activityLevel) {
        for (let i = colorScale.length - 1; i >= 0; i--) {
            if (activityLevel >= colorScale[i].threshold) {
                return colorScale[i].color;
            }
        }
        return "#EBEDF0";
    }

    // Haritanın başlangıç tarihini hesapla (Bugünden 365 gün önce)
    const startDate = new Date();
    startDate.setDate(today.getDate() - TOTAL_DAYS);

    // Başlangıç gününü Pazar'a (haftanın ilk günü) ayarla
    const dayOfWeek = startDate.getDay(); // 0: Pazar, 1: Pazartesi, ...
    startDate.setDate(startDate.getDate() - dayOfWeek);

    let currentDate = new Date(startDate);
    let lastMonth = -1;
    let weekCount = 0;

    // Ay etiketlerini oluştur
    for (let i = 0; i < TOTAL_DAYS + dayOfWeek + 7; i++) {
        const currentMonth = currentDate.getMonth();
        if (currentMonth !== lastMonth) {
            lastMonth = currentMonth;
            const weekIndex = Math.floor(i / 7);

            const monthLabel = document.createElement('div');
            monthLabel.className = 'month-label';
            monthLabel.textContent = monthNames[currentMonth];
            monthLabel.style.gridColumnStart = weekIndex + 1;
            monthLabelsContainer.appendChild(monthLabel);
        }

        // Gün hücresini oluştur
        const dayCell = document.createElement('div');
        dayCell.className = 'heatmap-day';

        // Sadece son 365 günü renklendir
        if (currentDate <= today && (today.getTime() - currentDate.getTime()) / (1000 * 3600 * 24) <= TOTAL_DAYS) {
            // Bu gün için aktivite verisi var mı kontrol et
            const dateString = currentDate.toISOString().split('T')[0];
            const activityData = window.heatmapData ? window.heatmapData.find(d => {
                // Date formatını kontrol et (DateTime objesi olabilir)
                const dataDate = typeof d.Date === 'string' ? d.Date.split('T')[0] : new Date(d.Date).toISOString().split('T')[0];
                return dataDate === dateString;
            }) : null;
            
            if (activityData) {
                // Gerçek veri kullan
                const activityLevel = activityData.QuestionCount || 0;
                dayCell.style.backgroundColor = getColor(activityLevel);
                dayCell.title = `${activityData.QuestionCount || 0} soru - ${currentDate.toLocaleDateString('tr-TR', { day: 'numeric', month: 'long', year: 'numeric' })}`;
                
                // Debug: İlk birkaç eşleşen veriyi konsola yazdır
                if (Math.random() < 0.1) { // %10 ihtimalle debug bilgisi
                    console.log('Found activity data:', activityData, 'for date:', dateString);
                }
            } else {
                // Veri yoksa boş bırak
                dayCell.style.backgroundColor = "#EBEDF0";
                dayCell.title = `0 soru - ${currentDate.toLocaleDateString('tr-TR', { day: 'numeric', month: 'long', year: 'numeric' })}`;
            }
        }

        heatmapGrid.appendChild(dayCell);

        // Bir sonraki güne geç
        currentDate.setDate(currentDate.getDate() + 1);
    }
});