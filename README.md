# 📧 MailApp - ASP.NET Core 8 MVC E-Posta Yönetim Sistemi

Bu proje, **.NET 6** ve **ASP.NET Core MVC** teknolojileri kullanılarak geliştirilmiş, tam kapsamlı bir e-posta yönetim simülasyonudur. Kullanıcı dostu arayüzü ve güçlü arka plan mimarisiyle, Gmail veya Outlook benzeri bir e-posta deneyimi sunmayı amaçlamaktadır.

## 🚀 Öne Çıkan Özellikler

* **Güvenli Kimlik Doğrulama:** ASP.NET Core Identity ile kullanıcı kayıt, giriş ve profil yönetimi.
* **Gelişmiş Klasörleme Sistemi:** Gelen Kutusu, Gönderilenler, Taslaklar, Yıldızlılar, Spam ve Çöp Kutusu modülleri.
* **Dinamik Kategoriler:** Mesajları İş, Aile, Eğitim ve Sosyal olarak renk kodlarıyla sınıflandırma.
* **Canlı Sayaçlar (Badges):** Sol menüde her klasör ve kategorideki güncel mesaj sayısını gösteren akıllı sayaçlar.
* **Zengin Metin Editörü:** Summernote entegrasyonu ile HTML formatında, görselli ve biçimlendirilmiş mail gönderme.
* **Kusursuz Arama Motoru:** HTML etiketlerini (tags) yoksayarak saf metin içinde, büyük/küçük harf duyarlılığı olmadan tek harfe kadar arama yapabilen özel algoritma.
* **Sayfalama (Pagination):** Performansı artırmak ve UI düzenini korumak için sayfa başına 13 mesaj gösteren dinamik sayfalama altyapısı.
* **İstatistiksel Profil Sayfası:** Kullanıcının e-posta alışkanlıklarını 8 farklı Widget ile (Toplam gelen, gönderilen, taslak vb.) gösteren detaylı profil ve bilgi güncelleme ekranı.

## 🛠️ Kullanılan Teknolojiler

**Backend (Arka Plan):**
* C# & .NET 6
* ASP.NET Core MVC
* Entity Framework Core
* ASP.NET Core Identity
* LINQ (Sorgulama ve Veri Manipülasyonu)

**Frontend (Arayüz):**
* HTML5, CSS3, JavaScript
* Bootstrap 5
* MetisMenu & Perfect Scrollbar
* Summernote (Rich Text Editor)

**Veritabanı:**
* Microsoft SQL Server

## 📸 Ekran Görüntüleri

<img width="1920" height="1080" alt="Ekran Görüntüsü (313)" src="https://github.com/user-attachments/assets/d4160eff-f244-486f-9b32-065ac579013d" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (314)" src="https://github.com/user-attachments/assets/04fe0f6e-b345-445d-8efe-b9eb10776fec" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (316)" src="https://github.com/user-attachments/assets/fb6aec18-98ac-4456-97d1-6a1668f5c5b4" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (317)" src="https://github.com/user-attachments/assets/28a4e912-fd62-491a-b066-9594302f5faf" />
<img width="2559" height="1314" alt="image" src="https://github.com/user-attachments/assets/f39788d3-6cd6-424e-bebd-e16169f6c1d5" />
<img width="1920" height="1080" alt="Ekran Görüntüsü (319)" src="https://github.com/user-attachments/assets/5fe9b41d-5a65-4221-b403-ece9be9f4caf" />

## ⚙️ Kurulum ve Çalıştırma

Projeyi yerel ortamınızda (localhost) çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1.  **Repoyu Klonlayın:**
    ```bash
    git clone [https://github.com/](https://github.com/)[KullaniciAdin]/[RepoAdin].git
    ```
2.  **Veritabanı Bağlantısını Ayarlayın:**
    `appsettings.json` dosyası içerisindeki `DefaultConnection` dizesini kendi SQL Server ayarlarınıza göre güncelleyin.
3.  **Migration İşlemlerini Uygulayın:**
    Package Manager Console (PMC) üzerinden aşağıdaki komutu çalıştırarak veritabanını oluşturun:
    ```powershell
    Update-Database
    ```
4.  **Projeyi Başlatın:**
    Visual Studio üzerinden `F5` tuşuna basarak veya terminalde `dotnet run` komutu ile projeyi ayağa kaldırın.

## 👤 Geliştirici

**Orçun Özşen** * GitHub: [@orcuno03](https://github.com/orcuno03)
* LinkedIn: (https://www.linkedin.com/in/orcunozsen/)
