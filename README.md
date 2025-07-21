# oBilet Case Study


Çalıştırmak için
```
dotnet watch --project oBilet.Presentation/oBilet.Presentation.csproj run
```

## Genel Bilgiler

* Proje CleanArchitecture ile yazıldı. 4 katmanlı mimariden oluşuyor.Projede External Servislerden gelen bilgileri gösterme olduğu için Core katmanında birşey yok genel olarak.
* Projede mümkün olduğunda SOLID prensiplerine uygun yazıldı.CQRS ve Mediator yerine Servis sınıfları yaklaşımı seçtim.
* Bazı çözümleri örnek olarak ekleyip her yer uygulamadım.Mesela bir tanesi Result Pattern.
