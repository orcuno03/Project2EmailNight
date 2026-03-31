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
**Kayıt Ol Ekranı:**
<img width="1905" height="957" alt="Ekran Görüntüsü (322)" src="https://github.com/user-attachments/assets/67f4d184-df3c-4112-9681-b9fc79f5edaa" />
**Kullanıcı Sözleşmesi:**
<img width="1920" height="1080" alt="Ekran Görüntüsü (313)" src="https://github.com/user-attachments/assets/d4160eff-f244-486f-9b32-065ac579013d" />
**Giriş Yap Ekranı:**
<img width="1920" height="1080" alt="Ekran Görüntüsü (314)" src="https://github.com/user-attachments/assets/04fe0f6e-b345-445d-8efe-b9eb10776fec" />
**Gelen Kutusu Sayfa Düzeni:**
<img width="1920" height="949" alt="Ekran Görüntüsü (323)" src="https://github.com/user-attachments/assets/368eaac4-060c-4541-9aea-00759399baae" />
**Gelen Kutusu Sayfalama:**
<img width="1920" height="954" alt="Ekran Görüntüsü (324)" src="https://github.com/user-attachments/assets/3ca3daef-93d4-47d3-93cd-dddd6e3e7216" />
**Yıldızlılar Sayfası:**
<img width="1920" height="953" alt="Ekran Görüntüsü (325)" src="https://github.com/user-attachments/assets/15f2f5f4-3c63-4e2c-b77c-980f9e4f5209" />
**Gönderilenler Sayfası:**
<img width="1920" height="953" alt="Ekran Görüntüsü (326)" src="https://github.com/user-attachments/assets/70d21bdf-47ec-4a83-9a8b-cf5d14c5597d" />
**Mail İçeriği Örnek Sayfa:**
<img width="1920" height="948" alt="Ekran Görüntüsü (327)" src="https://github.com/user-attachments/assets/b284478b-5f6f-4109-8397-0569f5b85c0f" />
**Metin Düzenleme İşlemi:**
<img width="1920" height="951" alt="Ekran Görüntüsü (328)" src="https://github.com/user-attachments/assets/155aedde-c0d4-4900-9da4-85a7ab33aa60" />
**Kategoriler Sayfası:**
<img width="1920" height="947" alt="Ekran Görüntüsü (329)" src="https://github.com/user-attachments/assets/0a9c2d7d-9a18-4b1f-af86-acca89274ca2" />

<img width="1920" height="948" alt="Ekran Görüntüsü (330)" src="https://github.com/user-attachments/assets/7a3cd201-7606-4789-bd5f-ec49b7eed8ea" />
**Doğrulama Kodu Göderim İşlemi:**
<img width="1920" height="956" alt="Ekran Görüntüsü (331)" src="https://github.com/user-attachments/assets/fd49a136-dccb-413b-ab03-4aefd1174921" />
**Aramalar Sekmesi Filtreleme İşlemi:**
<img width="1920" height="946" alt="Ekran Görüntüsü (333)" src="https://github.com/user-attachments/assets/86505cf6-0eb9-4157-88c7-75220ab224a8" />
**Profilim Sayfası:**
<img width="1920" height="947" alt="Ekran Görüntüsü (334)" src="https://github.com/user-attachments/assets/565be7e4-220e-459c-876e-60ed48df812c" />

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
