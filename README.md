# 🚀 Modern Schedule App - ASP.NET MVC ile Takvim Çizelgesi Uygulaması – FullCalendar Entegrasyonu
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım sekizinci proje olan ASP.NET MVC ile Takvim Çizelgesi Uygulaması projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu proje, ASP.NET MVC (Web Application – .NET Framework) yapısı kullanılarak geliştirilmiş, kullanıcıların etkinlik oluşturabileceği, bu etkinlikleri takvime sürükleyip bırakabileceği ve silme - güncelleme işlemlerini yapabileceği, etkinlik süresini uzatarak ayarlayabileceği ve ay - hafta - gün bazında her türlü zamanda etkinlikleri konumlandırabileceği bir etkinlik yönetim sistemidir. Proje, modern arayüzü ve güçlü planlama özellikleriyle özellikle toplantı, görev ve kişisel ajanda uygulamaları için örnek teşkil etmektedir. Takvim uygulaması dışında Kategori ve Etkinlik entity'lerinin CRUD işlemleri de yapılabilmektedir.

Bu projeyle amacım, bir kullanıcının günlük etkniliklerini düzenli bir şekilde takvim üzerinde kullanabileceği bir ortam sağlamaktır. Proje üzerinde gelişitirilebilir birçok yer bulunabilir. Amacım kendimi geliştirmek ve deneyim kazanmaktır.<br>

### 🎯 Geliştirme Amaçları<br>
Bu proje, aşağıdaki becerileri geliştirmek amacıyla hazırlanmıştır:
- ASP.NET MVC ile tam işlevsel bir web uygulaması geliştirmek
- Code First yaklaşımıyla veritabanı modelleme
- FullCalendar ile modern ve kullanıcı dostu bir arayüz oluşturmak
- AJAX ile sayfa yenilemeden veri işlemleri yapmak
- Etkinlik yönetimi gibi gerçek dünya problemlerine çözüm sunmak

---

### 📆 Takvim Özellikleri<br>
✅ FullCalendar Entegrasyonu
- dayGridMonth, timeGridWeek, timeGridDay gibi görünüm modlarıyla zengin takvim deneyimi
- Etkinlik sürükleyip bırakma (drag & drop)
- Yeni etkinlik oluşturma ve takvime bırakma
- Etkinliği doğrudan takvim üzerinde silme veya taşıma
- Takvim öğelerinde renk ve kategori bilgisi

✅ Kategori Yönetimi
- Etkinliklere kategori atayabilme
- Renk kodlu kategori tanımlamaları
- Her etkinlik, ait olduğu kategoriye göre farklı renkte görünür

✅ Veri Kalıcılığı
- Tüm etkinlikler veritabanına kayıt edilir
- Değişiklikler anlık olarak AJAX ile yansıtılır

✅ Code First Veritabanı Yapısı
- Event, Category sınıfları Entity Framework üzerinden oluşturuldu
- Migration işlemleriyle veritabanı şeması otomatik üretildi
- SQL Server üzerinde tam ilişkisel yapı kuruldu

✅ Türkçe Takvim Desteği
- locale: 'tr' ve locales-all.js kullanılarak takvim arayüzü tamamen Türkçeleştirildi
- “Bugün”, “Ay”, “Hafta”, “Gün” gibi başlıklar yerelleştirildi

---

###  🚀 Kullandığım Teknolojiler:<br>
💻 ASP.NET Web App (.NET Framework 4.7.2 (MVC Mimarisi))<br>
🗂️ Tek Katmanlı Dosya Yapısı - Presentation Layer<br>
📦 Entity Framework (Code First)<br>
🗄️ MS SQL Server<br>
🎨 FullCalendar (Bootstrap temalı)<br>
🛠️ jQuery & AJAX<br>
🎨 HTML5, CSS3, Bootstrap<br>
🗃️ Admin LTE v3 Teması<br>

Projede genel anlamda 1 bölüm bulunmaktadır.<br>
Ana Sayfa: Burada kullanıcı, Takvim Çizelgesi uygulaması ile etkinliklerini düzenleyebilir, Etkinlik ve Kategori entity'lerinin de CRUD işlemlerini yapabilir.<br>


---

## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/LifeSureMVC/blob/0014dca4b043c2e06433f2f84f59481dacc9a202/ss/localhost_44303_Default_Index%20(1).png" alt="image alt">
</div>
