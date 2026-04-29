🚀 GoalZone — Premier League Maç Takip Platformu

GoalZone, Premier League maçlarını takip edebileceğiniz; fikstür, puan durumu ve maç detaylarını dinamik olarak sunan ASP.NET Core tabanlı full-stack bir web uygulamasıdır.

## 🧱 Mimari Yapı

Proje, **N Katmanlı Mimari (N-Tier Architecture)** prensiplerine uygun olarak geliştirilmiştir.

Sistem aşağıdaki katmanlardan oluşmaktadır:

* **Web UI (MVC)** → Kullanıcı arayüzü (Sunum katmanı)
* **Web API** → UI ile backend arasında iletişimi sağlar
* **Business Layer** → İş kuralları ve uygulama mantığı
* **Data Access Layer** → Veritabanı işlemleri (Entity Framework Core)
* **DTO Layer** → Katmanlar arası veri transferini güvenli ve optimize şekilde sağlar

📌 Web UI katmanı veritabanına **doğrudan bağlanmaz.**
Tüm veri iletişimi **Web API** üzerinden **IHttpClientFactory** kullanılarak gerçekleştirilir.

🗃️ Veri Modeli

Sistemde kullanılan temel entity yapıları:

Team → Takım bilgileri

Fixture → Maç, skor ve hafta bilgisi

MatchEvent → Gol, kart ve oyuncu değişiklikleri

MatchStats → Maç istatistikleri

⚙️ Özellikler

🗓️ Fikstür & Maç Takibi
Haftaya göre maç listeleme
Canlı / tamamlanmış / yaklaşan maç ayrımı
Maç detay sayfası
Zaman sıralı olay akışı

🎯 Maç Detayları

Gol, kart ve değişikliklerin görünümü

🛠️ Admin Panel

Maç, olay ve istatistik yönetimi
CRUD işlemleri 
Merkezi kontrol paneli

🧰 Kullanılan Teknolojiler


ASP.NET Core 6 (Web API & MVC)
Entity Framework Core (Code First)
MS SQL Server
IHttpClientFactory
Swagger
Bootstrap 5

⚡ Öne Çıkanlar
N Katmanlı Mimari (N-Tier) ile ölçeklenebilir yapı
Web API tabanlı veri yönetimi
LINQ ile dinamik hesaplama
Gerçek zamanlı veri işleme mantığı
Güvenli ve sürdürülebilir mimari

Ana Sayfa

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/1.png)

Fikstür Gösterim

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/2.png)

Maç Detayları

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/3.png)

Puan Tablosu

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/4.png)

Admin Panel Sistemi 

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/5.png)

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/6.png)

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/7.png)

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/8.png)

![image](https://github.com/iremkosar/PremierLig/blob/001386d42bc6d2eb170879a9fca49024ee9a1034/PremierLig.WebUI/wwwroot/9.png)
