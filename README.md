<h1 align="center">🏠 Real Estate Dapper — Gayrimenkul Yönetim Platformu</h1>

<p align="center">
<img src="https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
<img src="https://img.shields.io/badge/Dapper-007ACC?style=for-the-badge&logo=dapper&logoColor=white" />
<img src="https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" />
<img src="https://img.shields.io/badge/SignalR-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
<img src="https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens" />
</p>

<p align="center">
<b>Real Estate Dapper</b>; yüksek performans odaklı, modern web teknolojileri ile inşa edilmiş bir emlak yönetim platformudur. Kullanıcılar için detaylı ilan inceleme, emlakçılar için ilan yönetimi ve adminler için kapsamlı bir kontrol paneli sunar.
</p>

<h2 style="border-bottom: 2px solid #512BD4; padding-bottom: 5px;">👨‍💼 Admin Paneli Özellikleri</h2>

Yönetim paneli üzerinden tüm dinamik içerikler anlık olarak yönetilebilir:

📍 İlan Yönetimi: Aktif/Pasif ilanların takibi ve düzenlenmesi.

📍 Kategori & Lokasyon: Emlak türlerinin ve bölge bazlı verilerin yönetimi.

📍 Anlık İstatistikler: Toplam ilan, personel ve kategori bazlı verilerin takibi.

📍 SignalR Dashboard: Canlı verilerle güncellenen etkileşimli yönetim ekranı.

📍 Mesaj ve İletişim: Kullanıcılardan gelen taleplerin yönetimi.

<h2 style="border-bottom: 2px solid #512BD4; padding-bottom: 5px;">🧠 Teknik Altyapı & Mimariler</h2>

[!IMPORTANT]
Proje, özellikle veri erişim hızını optimize etmek amacıyla Dapper Micro-ORM kullanılarak geliştirilmiştir.

🧰 AspNet Core 8.0 Web API & MVC

🏗️ N-Tier (Katmanlı) Mimari: Sorumlulukların net ayrıştırıldığı sürdürülebilir yapı.

🗃️ Dapper Micro-ORM: EF Core'a kıyasla yüksek performanslı veri yönetimi.

🏗️ Repository Design Pattern: Merkezi veri erişim yönetimi.

🔐 JWT Authentication: Güvenli kimlik doğrulama mekanizması.

📡 SignalR Entegrasyonu: Real-time veri akışı ve dinamik dashboard.

🗺️ Leaflet.js: İnteraktif harita desteği.

<h2 style="border-bottom: 2px solid #512BD4; padding-bottom: 5px;">💻 Kullanılan Teknolojiler</h2>

🚀 AspNet Core 8.0 – Backend API ve Frontend MVC mimarisi.

🗄️ MSSQL – İlişkisel veritabanı yönetimi.

⚡ Dapper – Yüksek performanslı veri eşleme (mapping).

🔐 JWT (JSON Web Token) – Güvenli yetkilendirme altyapısı.

📡 SignalR – Gerçek zamanlı veri iletişimi.

🎨 Bootstrap & SCSS – Modern ve responsive (duyarlı) arayüz tasarımı.

🌐 JavaScript & Leaflet.js – Harita ve dinamik UI etkileşimleri.

🧪 Swagger – API uç noktalarının dökümantasyonu ve testi.

<h2 style="border-bottom: 2px solid #512BD4; padding-bottom: 5px;">🌟 Öne Çıkan Uygulama Özellikleri</h2>

🔍 Gelişmiş Filtreleme: Kategori ve lokasyona göre hızlı ilan arama.

📊 Canlı İstatistik Paneli: Sayfa yenilenmeden güncellenen veriler.

📍 Harita Desteği: İlanların fiziksel konumlarının gösterimi.

🔐 Güvenli Admin Paneli: JWT ile korunmuş yetkilendirme sistemi.

📂 DTO Kullanımı: Veri taşıma süreçlerinde tip güvenliği ve performans.

<h2 style="border-bottom: 2px solid #512BD4; padding-bottom: 5px;">🚀 Kurulum</h2>

- Bu depoyu klonlayın: git clone https://github.com/ozkankaratas/RealEstate_Dapper_Api.git
  
- appsettings.json dosyasındaki SQL bağlantı dizesini güncelleyin.
  
- Update-Database komutuyla veritabanını oluşturun (veya paylaşılan scripti çalıştırın).
  
- Projeyi ayağa kaldırın!

<h2>Proje Veritabanı Diyagramı : </h2>

<img width="1857" height="822" alt="Ekran görüntüsü 2026-02-26 035200" src="https://github.com/user-attachments/assets/595d6296-950a-47aa-8508-dce9668010ea" />

<h2>Swagger Dokümantasyonu : </h2>

<img width="1920" height="7580" alt="screencapture-localhost-44338-swagger-index-html-2026-02-26-03_35_18" src="https://github.com/user-attachments/assets/df60ec90-473f-4b6f-b34d-3b6685135422" />

<h2>Ana Sayfa Alanı : </h2>

<img width="1500" height="6500" alt="screencapture-localhost-44381-Default-Index-2026-02-26-03_08_56" src="https://github.com/user-attachments/assets/00307ad3-9bc7-467b-8da5-c1314a29e83d" />
<img width="1500" height="6500" alt="screencapture-localhost-44381-Default-Index-2026-02-26-03_08_36" src="https://github.com/user-attachments/assets/d04028f0-f076-46e8-a374-e12723a82abb" />

<h2>İlanlar Sayfası : </h2>

<img width="1900" height="905" alt="Ekran görüntüsü 2026-02-26 030257" src="https://github.com/user-attachments/assets/12f84e4a-35e1-46b1-9820-13a02b324543" />

<h2> İlan Detay Sayfası : </h2>

<img width="1920" height="2911" alt="screencapture-localhost-44381-ilan-ilan-detay-3-2026-02-26-03_07_59" src="https://github.com/user-attachments/assets/c61467bb-b540-4143-ba9b-04366bf76747" />

<h2> Admin Paneli </h2>

<img width="1920" height="1398" alt="screencapture-localhost-44381-Dashboard-Index-2026-02-26-03_29_05" src="https://github.com/user-attachments/assets/ac3cab7f-b982-4bbd-8b4d-e282738ea2b5" />
<img width="1903" height="908" alt="Ekran görüntüsü 2026-02-26 033104" src="https://github.com/user-attachments/assets/0fea04d6-8183-445a-beb3-ee5033ad60f6" />

<h2> Emlakçı Paneli </h2>
<img width="1920" height="1246" alt="screencapture-localhost-44381-EstateAgent-Dashboard-Index-2026-02-26-03_32_57" src="https://github.com/user-attachments/assets/1e74b1ce-8b53-4c82-8f20-e7fd57a7e074" />
<img width="1920" height="1127" alt="screencapture-localhost-44381-EstateAgent-MyAdverts-CreateAdvert-2026-02-26-03_33_29" src="https://github.com/user-attachments/assets/0078d3c6-9e9e-4b68-8471-3a37bbf239a2" /> 

<h2> Özel Hata Sayfaları </h2>
<h3> 404 Sayfası </h3>
<img width="1920" height="1193" alt="screencapture-localhost-44381-EstateAgent-Dashboard-Inxxx-2026-02-26-04_04_58" src="https://github.com/user-attachments/assets/a22ae2c0-36db-4f75-8998-c4ccecc64787" />
<h3> 500 Sayfası </h3>
<img width="1920" height="885" alt="screencapture-localhost-44381-EstateAgent-Dashboard-Index-2026-02-26-04_04_44" src="https://github.com/user-attachments/assets/90f2378b-a4dc-4b47-af25-8425f4e504fa" />
