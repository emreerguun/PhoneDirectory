  Veritabanı oluşturmak için Migration hazırlanmıştır...
  
  PhoneDirectory.WebApi/appsettings.json/Connection String= 
  "ConnectionStrings": {"DefaultConnection": "...;Database=PhoneDirectoryDB;Trusted_Connection=True;"}
  
  Request işlemleri Postman uygulaması ile test edilmiştir.
  
  Tüm kullanıcıları listeleme
  GET:
  https://localhost:44335/api/users
  ----------------------
  Kullanıcı ID'sine göre kullanıcı listeleme
  GET:
  https://localhost:44335/api/users/getuserbyid/{userID}
  ----------------------
  Kullanıcı Detay Listeleme
  GET:
  https://localhost:44335/api/users/getuserdetail/{userID}
  ----------------------
  Kullanıcı Ekleme
  POST:
  https://localhost:44335/api/users/adduser
  kullanıcı eklemek için örnek json çıktısı: {"name": "Ali","surname": "Veli","company": "ABC"}
  ----------------------
  Kullanıcı Güncelleme
  PUT:
  https://localhost:44335/api/users/updateuser/{userID}
  kullanıcı güncellemek için örnek json çıktısı: {"name": "Ali","surname": "Veli","company": "ABC"}
  ----------------------  
  Kullanıcı Sil
  DELETE:
  https://localhost:44335/api/users/deleteuser/{userID}
  ----------------------  
  Kullanıcının Bulunduğu Konumları Çoktan Aza Sıralama
  GET:
  https://localhost:44335/api/users/descending-location/{userID}
  ----------------------  
  
  
  Kullanıcı ID'sine göre Bilgilerini Listeleme
  GET:
  https://localhost:44335/api/contactinfos/{userID}
  ----------------------
  
  Kullanıcı Bilgisi Ekleme
  POST:
  https://localhost:44335/api/contactinfos/addcontactinfo/{userID}
  kullanıcı bilgisi eklemek için örnek json çıktısı: {"infoType": 2,"infoContent": "Istanbul"} 
  NOT:InfoType:0 (Telefon), InfoType:1 (Email), InfoType:2 (Location)
  ----------------------
  
  Kullanıcı Bilgisi Silme
  DELETE:
  https://localhost:44335/api/contactinfos/deletecontactinfo/{userID}/{contactID}
  
  
  
