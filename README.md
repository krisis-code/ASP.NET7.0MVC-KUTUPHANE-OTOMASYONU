# Kütüphane Yönetim Web Uygulaması

Bu projede ASP .NET Core 7.0 ve MVC gibi en güncel Microsoft teknolojilerini kullanarak geliştirilmiş bir web uygulaması örneği bulunmaktadır. Proje,  okulda  proje olarak kullanabileceğiniz bir kütüphane yönetim sistemidir. 

## Proje Özeti

- ASP.NET Core 7.0 (Visual Studio 2022 kullanarak)
- MVC (Model View Controller)
- Entity Framework Core
- ASP.NET Core Identity (Login ve Yetkilendirme)
- Repository Pattern

Teknolojiler kullanılmıştır.

## Kullanılan Teknolojiler

- **ASP.NET Core 7.0**
- **Visual Studio 2022**
- **Microsoft SQL Server 2022**
- **Entity Framework Core**
- **ASP.NET Core Identity**
- **MVC (Model View Controller)**
- **Repository Pattern**

## Proje eklenebilicek geliştirmeler

- N tier katmanlı mimari uygulabilir
- Eklenen kullanıcıya otomatik rol eklenmesi
- Hazır mimari kullanılarak kitap takip uygulamasına çevirilebilir
- Günlük okunan kitap takibi , haftalık , aylık kitap okuma raporlaması ve okunan kitap bilgisi diğer kullanıcılar ile paylaşılması.


## Kurulum ve Başlarken

### Gereksinimler

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) veya [Visual Studio Code](https://code.visualstudio.com/)
- SQL Server (veya başka bir veritabanı sunucusu)

### Kurulum Adımları

1. Bu depoyu klonlayın veya indirin:

    ```sh
    git clone https://github.com/kullanıcıadı/projeadı.git
    ```

2. Proje dizinine gidin:

    ```sh
    cd projeadı
    ```

3. Gerekli bağımlılıkları yükleyin:

    ```sh
    dotnet restore
    ```

4. Veritabanını oluşturun ve uygulayın:

    - `appsettings.json` dosyasındaki bağlantı dizesini (`ConnectionStrings:DefaultConnection`) kendi veritabanı ayarlarınıza göre güncelleyin.
    
    - Veritabanı migration'larını uygulayın:

      ```sh
      dotnet ef database update
      ```

### Kullanım

Uygulamayı çalıştırmak için aşağıdaki komutu kullanın:

```sh
dotnet run
