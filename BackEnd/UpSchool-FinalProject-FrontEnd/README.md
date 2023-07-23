# 🚀 UpSchool Full Stack Developer Bitirme Projesi

# ⚙️ Kullanılan Teknolojiler
* Asp .Net 7 ile Entity Framework Core
* Blazor
* CQRS Pattern
* Selenium
* SMTP
* CodeFirst yaklaşımı
* Clean Architecture

# :card_file_box: Proje 6 Katmandan Oluşur:
* Domain
* Infrastructure 
* Application
* WebApi
* Wasm 
* Console

# 📝 Notlar
* Projede veritabanı olarak PostgreSql kullanılmıştır.
* Mailler her OrderEvent eklendiğinde gitmektedir.
* Projenin Front-End kısmı yakın zamanda eklenecektit.

# :paperclips: Projeyi Çalıştırmak İçin Gerekli Konfigürasyonlar
* FinalProject.WebApi projesi içerisindeki appsetting.json dosyası içerisinde gerekli düzenlemelerin yapılması gerekir.

` "ConnectionStrings": {
    "PostgreSQL": "User ID=***;Password=***;Host=***;Port=***;Database=UpSchoolProject;"
  } `
  
  * Projeyi çalıştırabilmek için Solution üzerinden Configure Startup Projects sekmesinden Multiple startup projects seçeneğini seçip FinalProject.WebApi, FinalProject.Console, FinalProject.Wasm projesini belirtilen sırada çalıştırmalısınız.

# :spiral_notepad: Projeye Ait Ekran Görüntüleri
* Log Ekranı  
![Ekran Görüntüsü (169)](https://github.com/SongulBayer/NetCore5.0/assets/63016233/ca0e6c5c-d731-4ead-af3e-d3499197b763)  
* Console Ekranı  
![Ekran Görüntüsü (170)](https://github.com/SongulBayer/NetCore5.0/assets/63016233/b7c43e84-af90-48bb-9f05-5dddf0c05619)  
* Swager Ekranı  
![api](https://github.com/SongulBayer/NetCore5.0/assets/63016233/02b6c102-4c00-422d-94ef-7402d79cf3a5)  
* Veri Tabanı Tabloları  
-> Product Tablosu  
![Ekran Görüntüsü (172)](https://github.com/SongulBayer/NetCore5.0/assets/63016233/956b919e-7556-40d7-a8b0-acb6393b1cdb)  
-> Orders Tablosu  
![Ekran Görüntüsü (171)](https://github.com/SongulBayer/NetCore5.0/assets/63016233/40eea47c-3f37-42b6-8f58-5ad27752c49c)  
-> OrderEvents Tablosu  
![Ekran Görüntüsü (171)](https://github.com/SongulBayer/NetCore5.0/assets/63016233/470b6c1c-d643-45af-a8d5-5240a21f9cee)  








