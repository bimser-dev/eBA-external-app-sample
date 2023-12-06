# eBA-external-app-sample
Harici uygulamalardan eBA Workflow &amp; Form kullanımının gösterildiği örnek bir projedir.

# eBA Form Mobil Uygulama Geliştirme Rehberi
Bu rehber, eBA Formlarınıza özel mobil uygulamanızı tasarladıktan sonra süreç işlemlerini nasıl gerçekleştirebileceğinizi belirtmek amacıyla oluşturulmuştur. Bütün bu işlemler **eBARestAPI** adlı API üzerinden gerçekleştirilmektedir. Bu rehberde kullanmanız gereken tüm endpointler sırasıyla verilmiştir.

# Örnek Süreç ve Form Projesi
Örnek süreç **Oracle** ortam için deploy edileceği zaman **eBA Configuration Manager -> Compiler** sekmesi altındaki uzunluklar en az 100 karakter olarak belirlenip servisler restart edilmelidir.

Örnek form projesindeki endpointler default olarak localhost'a bakmaktadır. Projeyi çalıştırmak için bu endpointleri kendi endpointiniz ile değiştirmelisiniz.

## Endpoint Authentication 
**Documents/SaveDocumentData**, **Queries/Execute**, **ProcessEvents/Events** ve **ProcessEvents/Continue** endpointlerinde _body_ içerisinde gönderilen _Token_ parametresiyle authentication işlemi yapılmaktadır. Burada doldurulan değerler **Login/Login** endpointinin responsudur. 

**ProcessEvents/StartProcess** endpointinde authentication direkt olarak _body_ içerisinde gönderilen _UserId_ ve _Password_ parametrelerinden sağlanmaktadır.

## Endpoints

### ProcessEvents/**StartProcess** `[POST]`
---
Süreç başlatmanızı sağlayan endpointtir.
#### Request Example
```json
{
  "UserId": "admin",
  "Password": "0",
  "Language": "Turkish",
  "Process": "ProjectName",
  "Parameters": [
	{
	    "Name":"FlowInitiatorId",
           "Value":"admin"
    }
  ]
}
```
#### Response Example
```json
{
    "ProcessId": 503,
    "RequestId": 2,
    "Status": false,
    "ErrorMessage": null,
    "ErrorCode": 0
}
```
#### Headers
**Content-Type**: `application/json`
#### Body Parameters
- **UserId** (`string`): Süreci başlatacak kullanıcı.
- **Password** (`string`): Süreci başlatacak kullanıcının şifresi.
- **Language** (`string`): Dil parametresi.
- **Process** (`string`): Başlatılacak sürecin adı.
- **Parameters** (`array`): Süreç üzerinde bulunan public değişkenlere değer gönderilmesini sağlar. Name-Value şeklinde array olarak gönderilmelidir.
```json
{
  "Parameters": [
    {
        "Name":"FlowInitiatorId",
        "Value":"admin"
    },
    {
        "Name":"ParentFlowId",
        "Value":"321"
    }
  ]
}
``` 

### Queries/**Execute** `[POST]`
---
Süreç içerisindeki nesnelerinizi (ComboBox, Table, ListBox vs.) doldurmak için kullandığınız eBA Integration sorgularınızdaki verileri kendi mobil uygulama tarafında da kullanabilmek için geliştirilen endpointtir.
#### Request Example
```json
{
    "Token": {
        "idField": "b2714284-bf62-4c46-88bb-800931b3ff55",
        "languageField": "Turkish",
        "userIdField": "admin",
        "usernameField": "Admin .",
        "twoFactorAuthenticationEnabledField": false,
        "mFAParamsField": null,
        "webDelegationField": true,
        "delegationIdField": 0,
        "captchaImageField": null,
        "webViewUrlField": "http://localhost/eba.net/default.aspx?ep=7MLf1Y1Oe5AP%2fGV9whUQS5UloqC1xjmcSlSxIZoj8nLvJwCTqBJM1c6uxEWyI%2b5O57cXe6y%2b%2fIz62qxdraraW0ei8h43Yw8gGbnd66O8Sj7MxessteVPnGYcgZ8m6s%2fdT%2f9fzth6y8jTdU3pDinXQA1CZ9WXtFHnI%2brK%2bmVjtUCYMs2u33WS6lbKeKK48WtuHj959NbAP4kSH5BDiQTMJ8J%2foSFoWULsvdNE9RWPtyQp6y6xrxRCgG99mkmsodRga4pssEwvrYp%2fqZpMfzHPPQ%3d%3d"
    },
    "ConnectionName": "DEGISIKLIKYONETIMI",
    "QueryName": "GetUsersByDepartment",
    "Parameters": [
        {
            "Name": "DEPID",
            "Value": "G0"
        }
    ]
}
```
#### Response Example
```json
{
    "Data": [
        {
            "ID": "test",
            "FULLNAME": "Test User"
        },
        {
            "ID": "test1",
            "FULLNAME": "Test User"
        },
        {
            "ID": "test2",
            "FULLNAME": "Test User"
        },
        {
            "ID": "test3",
            "FULLNAME": "Test User"
        },
        {
            "ID": "test7",
            "FULLNAME": "Test User"
        },
    ],
    "Status": true,
    "ErrorMessage": null,
    "ErrorCode": 0
}
```
#### Headers
**Content-Type**: `application/json`
#### Body Parameters
- **ConnectionName** (`string`): Sorgunun içinde bulunduğu bağlantı bilgisinin adıdır. CaseSensitive bir yapıya sahiptir, birebir aynı ad verilmelidir.
- **QueryName** (`string`): Bağlantı bilgisinin içinde çalıştırmak istediğimiz sorgunun adıdır. CaseSensitive bir yapıya sahiptir, birebir aynı ad verilmelidir.
- **Parameters** (`array`): Eğer sorgunun içerisinde kullanılan parametreler varsa bunlar, Name-Value şeklinde bir array olarak gönderilmelidir. Örnek olarak parametreler aşağıdaki gibi gönderilebilir.
```json
{
  "Parameters": [
    {
      "Name": "DepartmentId",
      "Value": "G4"
    },
    {
      "Name": "ProfessionId",
      "Value": "T2"
    },
    {
      "Name": "Date",
      "Value": "27.11.2023"
    }
  ]
}
```
### Documents/**SaveDocumentData** `[POST]`
---
Süreç içerisinde bulunan form ve form nesnelerinin verilerini güncellemeye yarayan endpointtir. 
#### Request Example
```json
{
  "Token": {
    "idField": "6fdab9ef-3208-4524-95c3-449a489b33a3",
    "languageField": "Turkish",
    "userIdField": "admin",
    "usernameField": "Admin .",
    "twoFactorAuthenticationEnabledField": false,
    "mFAParamsField": null,
    "webDelegationField": true,
    "delegationIdField": 0,
    "captchaImageField": null,
    "webViewUrlField": "http://localhost/eba.net/default.aspx?ep=7MLf1Y1Oe5AP%2fGV9whUQS5UloqC1xjmcSlSxIZoj8nLvJwCTqBJM1c6uxEWyI%2b5O57cXe6y%2b%2fIz62qxdraraW0ei8h43Yw8gGbnd66O8Sj7MxessteVPnGYcgZ8m6s%2fdT%2f9fzth6y8jTdU3pDinXQA1CZ9WXtFHnI%2brK%2bmVjtUCYMs2u33WS6lbKeKK48WtuHj959NbAP4kSH5BDiQTMJ8J%2foSFoWULsvdNE9RWPtyQp6y6xrxRCgG99mkmsodRga4pssEwvrYp%2fqZpMfzHPPQ%3d%3d"
  },
  "ProcessId": 488,
  "Forms": [
    {
      "Name": "Form",
      "Controls": [
        {
          "Type": "TextBox",
          "Name": "txtAd",
          "Value": "Talha"
        },
        {
          "Type": "TextBox",
          "Name": "txtSoyad",
          "Value": "Özer"
        },
        {
          "Type": "ComboBox",
          "Name": "cmbDepartman",
          "Value": {
            "Key": "G1",
            "Value": "Üretim"
          }
        },
        {
          "Type": "RadioList",
          "Name": "rdlstCinsiyet",
          "Value": {
            "Key": "1",
            "Value": "Erkek"
          }
        },
        {
          "Type": "CheckBox",
          "Name": "AcikMi",
          "Value": false
        },
        {
          "Type": "RadioButton",
          "Name": "rdbSecenek2",
          "Value": true
        },
        {
          "Type": "CheckBoxList",
          "Name": "chklstKullanicilar",
          "Value": [
            {
              "Key": "adogru",
              "Value": "Ali Doğru"
            }
          ]
        },
        {
          "Type": "ListBox",
          "Name": "lstMeyveler",
          "Value": [
            {
              "Key": "2",
              "Value": "Armut"
            }
          ]
        },
        {
          "Type": "DetailsGrid",
          "Name": "dtgKayitliKullanicilar",
          "Value": [
            {
              "Columns": [
                {
                  "Type": "TextBox",
                  "Name": "DTG_TXT_Ad",
                  "Value": "Bimser1"
                },
                {
                  "Type": "TextBox",
                  "Name": "DTG_TXT_Soyad",
                  "Value": "Çözüm2"
                },
                {
                  "Type": "ComboBox",
                  "Name": "DTG_CMB_Ehliyet",
                  "Value": {
                    "Key": "B",
                    "Value": "B Sınıfı"
                  }
                }
              ]
            }
          ]
        },
        {
          "Type": "Table",
          "Name": "tblPersoneller",
          "Value": [
            {
              "Columns": [
                {
                  "Name": "ID",
                  "Value": "adogru"
                },
                {
                  "Name": "FULLNAME",
                  "Value": "Ali Doğru"
                }
              ]
            },
            {
              "Columns": [
                {
                  "Name": "ID",
                  "Value": "hkar"
                },
                {
                  "Name": "FULLNAME",
                  "Value": "Hüseyin Kar"
                }
              ]
            }
          ]
        },
        {
          "Type": "Details",
          "Name": "dtEnvanter",
          "Value": {
            "DetailsForm": "EnvanterFormu",
            "Rows": [
              {
                "Controls": [
                  {
                    "Type": "ComboBox",
                    "Name": "cmbInventoryType",
                    "Value": {
                      "Key": "2",
                      "Value": "Monitör"
                    }
                  },
                  {
                    "Type": "TextBox",
                    "Name": "txtSeriNumarasi",
                    "Value": "123456789"
                  }
                ]
              },
              {
                "Controls": [
                  {
                    "Type": "ComboBox",
                    "Name": "cmbEnvanterTipi",
                    "Value": {
                      "Key": "3",
                      "Value": "Telefon"
                    }
                  },
                  {
                    "Type": "TextBox",
                    "Name": "txtSeriNumarasi",
                    "Value": "2424567123"
                  }
                ]
              }
            ]
          }
        }
      ]
    }
  ]
}
```
#### Response Example
```json
{
    "Status": true,
    "ErrorMessage": null,
    "ErrorCode": 0
}
```
#### Headers
**Content-Type**: `application/json`
#### Body Parameters
* **ProcessId** (`int`): Doldurulmak/güncellenmek istenen formların hangi süreç içinde olduğunu belirtir. Endpoint bu Id ile process’e ve formlara erişerek formların update edilmesini sağlar.
* **Forms** (`array`): Doldurulmak istenen formun adını ve içerisindeki nesneleri içerir. Süreç altındaki hangi formların hangi alanlarını dolduracağınızı buradan belirtebilirsiniz.
    * **Name** (`string`): Doldurulmak istenen formun adını tutar. CaseSensitive bir yapıya sahiptir, birebir aynı ad verilmelidir.
     * **Controls** (`array`): Doldurulmak istenen form controlünün bilgilerini tutar.
        * **Type** (`string`): Doldurmak istediğinz alanın tipini belirtmelisiniz. Toplam 10 farklı tip bulunmaktadır bunlar; _TextBox_, _ComboBox_, _RadioList_, _ListBox_, _CheckBox_, _RadioButton_, _CheckBoxList_, _DetailsGrid_, _Details_ ve _Table_. 
        * **Name** (`string`): Doldurmak istediğiniz alanın adını belirtmelisiniz. CaseSensitive bir yapıya sahiptir, birebir aynı ad verilmelidir.
        * **Value** (`object`): Doldurmak istediğiniz alanın değerini belirttiğimiz kısımdır. Bu parametre her nesnede farklı veri yapısı kullanmaktadır. Örneğin TextBox için string tutarken, ComboBox için KeyValue tutabilir. Hangi nesne tipinde hangi veri tipinin kullanılması gerektiğini aşağıdaki örneklerden öğrenebilirsiniz. ListBox ve CheckBoxList nesnelerinde nesne üzerindeki değerler mutlaka gönderilmelidir aksi takdirde API ayrıştırma yaparak gelmeyen dataları siler, yeni gönderilen dataları ekler. Bunun sebebi bu nesnelerin multiple selection yapısını da desteklemeleridir. Details, DetailsGrid ve Table nesnelerinde de gönderilen datalar row olarak eklenmektedir, bu 3 nesnenin üzerindeki rowların hepsinin gönderilmesine gerek yoktur, ayrıştırma (ekle/sil) işlemi yapmamaktadır.

#### TextBox
```json
{
  "Type": "TextBox",
  "Name": "txtName",
  "Value": "John"
}
```
#### ComboBox
```json
{
  "Type": "ComboBox",
  "Name": "cmbDrivingLicence",
  "Value": {
    "Key": "B",
    "Value": "B Driving Licence"
  }
}
```
#### RadioList
```json
{
  "Type": "ListBox",
  "Name": "rdlstFruits",
  "Value": {
    "Key": "3",
    "Value": "Apple"
  }
}
```
#### CheckBox
```json
{
  "Type": "CheckBox",
  "Name": "isSelected",
  "Value": false
}
```
#### RadioButton
```json
{
  "Type": "RadioButton",
  "Name": "rdbOpen",
  "Value": true
}
```
#### CheckBoxList
```json
{
  "Type": "CheckBoxList",
  "Name": "chlstPermissions",
  "Value": [
    {
      "Key": "0",
      "Value": "Editor"
    },
    {
      "Key": "1",
      "Value": "Content Creator"
    }
  ]
}
```
#### ListBox
```json
{
  "Type": "ListBox",
  "Name": "lstMode",
  "Value": [
    {
      "Key": "2",
      "Value": "Write"
    },
    {
      "Key": "5",
      "Value": "Read"
    }
  ]
}
```
#### DetailsGrid
```json
{
  "Type": "DetailsGrid",
  "Name": "dtgDrivers",
  "Value": [
    {
      "Columns": [
        {
          "Type": "TextBox",
          "Name": "txtName",
          "Value": "John"
        },
        {
          "Type": "TextBox",
          "Name": "txtSurname",
          "Value": "Doe"
        },
        {
          "Type": "ComboBox",
          "Name": "cmbDriverLicence",
          "Value": {
            "Key": "B",
            "Value": "B Driving Licence"
          }
        }
      ]
    },
    {
      "Columns": [
        {
          "Type": "TextBox",
          "Name": "txtName",
          "Value": "Jane"
        },
        {
          "Type": "TextBox",
          "Name": "txtSurname",
          "Value": "Doakes"
        },
        {
          "Type": "ComboBox",
          "Name": "cmbDriverLicence",
          "Value": {
            "Key": "A",
            "Value": "A Driving Licence"
          }
        }
      ]
    }
  ]
}
```
#### Table
```json
{
  "Type": "Table",
  "Name": "tblUsers",
  "Value": [
    {
      "Columns": [
        {
          "Name": "ID",
          "Value": "jdoe"
        },
        {
          "Name": "FULLNAME",
          "Value": "John Doe"
        }
      ]
    },
    {
      "Columns": [
        {
          "Name": "ID",
          "Value": "jdoakes"
        },
        {
          "Name": "FULLNAME",
          "Value": "Jane Doakes"
        }
      ]
    }
  ]
}
```
#### Details
```json
{
  "Type": "Details",
  "Name": "dtInventories",
  "Value": {
    "DetailsForm": "InventoryForm",
    "Rows": [
      {
        "Controls": [
          {
            "Type": "ComboBox",
            "Name": "cmbInventoryType",
            "Value": {
              "Key": "2",
              "Value": "Monitör"
            }
          },
          {
            "Type": "TextBox",
            "Name": "txtSerialNumber",
            "Value": "123456789"
          }
        ]
      },
      {
        "Controls": [
          {
            "Type": "ComboBox",
            "Name": "cmbInventoryType",
            "Value": {
              "Key": "3",
              "Value": "Phone"
            }
          },
          {
            "Type": "TextBox",
            "Name": "txtSerialNumber",
            "Value": "2424567123"
          }
        ]
      }
    ]
  }
}
```
### ProcessEvents/**Events** `[POST]`
---
İlerletmek istediğiniz sürecin hangi aşamada hangi event butonlara sahip olduğunu geriye döndürür.
#### Request Example
```json
{
    "Token": {
        "idField": "7ff44150-eadc-4319-ab03-f9134fb5ea9f",
        "languageField": "Turkish",
        "userIdField": "admin",
        "usernameField": "Admin .",
        "twoFactorAuthenticationEnabledField": false,
        "mFAParamsField": null,
        "webDelegationField": true,
        "delegationIdField": 0,
        "captchaImageField": null,
        "webViewUrlField": "http://localhost/eba.net/default.aspx?ep=7MLf1Y1Oe5AP%2fGV9whUQS5UloqC1xjmcSlSxIZoj8nLvJwCTqBJM1c6uxEWyI%2b5O57cXe6y%2b%2fIz62qxdraraW0ei8h43Yw8gGbnd66O8Sj7MxessteVPnGYcgZ8m6s%2fdT%2f9fzth6y8jTdU3pDinXQA1CZ9WXtFHnI%2brK%2bmVjtUCYMs2u33WS6lbKeKK48WtuHj959NbAP4kSH5BDiQTMJ8J%2foSFoWULsvdNE9RWPtyQp6y6xrxRCgG99mkmsodRga4pssEwvrYp%2fqZpMfzHPPQ%3d%3d"
    },
    "ProcessId": 511,
    "RequestId": 2
}
```
#### Response Example
```json
{
  "ShowEvents": true,
  "OwnedStatus": 0,
  "OwnedById": null,
  "DetailedEvents": [
    {
      "idField": 4,
      "descriptionField": "Gönder",
      "reasonRequiredField": false,
      "validationField": true,
      "eventFormField": "",
      "eventIconField": "approve.png",
      "confirmField": false,
      "fastApproveField": true
    },
    {
      "idField": 7,
      "descriptionField": "İptal",
      "reasonRequiredField": false,
      "validationField": false,
      "eventFormField": "",
      "eventIconField": "reject.png",
      "confirmField": false,
      "fastApproveField": true
    }
  ],
  "ErrorCode": 0,
  "ErrorMessage": null,
  "Status": true
}
```
#### Headers
**Content-Type**: `application/json`
#### Body Parameters
- **ProcessId** (`int`): Eventlarını getirmek istediğiniz süreç numarası.
- **RequestId** (`int`): Eventlarını getirmek istediğiniz sürecin istek numarası.

### ProcessEvents/**Continue** `[POST]`
---
Sürecinizi bir sonraki adıma ilerletmek için kullanacağınız endpointtir.
#### Request Example
```json
{
  "Token": {
    "idField": "7ff44150-eadc-4319-ab03-f9134fb5ea9f",
    "languageField": "Turkish",
    "userIdField": "admin",
    "usernameField": "Admin .",
    "twoFactorAuthenticationEnabledField": false,
    "mFAParamsField": null,
    "webDelegationField": true,
    "delegationIdField": 0,
    "captchaImageField": null,
    "webViewUrlField": "http://localhost/eba.net/default.aspx?ep=7MLf1Y1Oe5AP%2fGV9whUQS5UloqC1xjmcSlSxIZoj8nLvJwCTqBJM1c6uxEWyI%2b5O57cXe6y%2b%2fIz62qxdraraW0ei8h43Yw8gGbnd66O8Sj7MxessteVPnGYcgZ8m6s%2fdT%2f9fzth6y8jTdU3pDinXQA1CZ9WXtFHnI%2brK%2bmVjtUCYMs2u33WS6lbKeKK48WtuHj959NbAP4kSH5BDiQTMJ8J%2foSFoWULsvdNE9RWPtyQp6y6xrxRCgG99mkmsodRga4pssEwvrYp%2fqZpMfzHPPQ%3d%3d"
  },
  "ProcessId": 509,
  "RequestId": 3,
  "EventId": 6,
  "ReasonText": "This is reason text",
  "EventFormId": 0,
  "HasSigned": false
}
```
#### Response Example
```json
{
    "HasKEP": false,
    "HasSignature": false,
    "HasEventForm": false,
    "HasReason": false,
    "HasValidation": false,
    "ValidationDescription": null,
    "ContinueStatus": true,
    "OwnedStatus": 0,
    "OwnedById": null,
    "EventFormPath": null,
    "ProjectCaption": "ProjectName",
    "EventFormId": 0,
    "Document": null,
    "AddTimeStamp": false,
    "HasSigned": false,
    "SignType": 0,
    "ErrorCode": 0,
    "ErrorMessage": null,
    "Status": true
}
```
#### Headers
**Content-Type**: `application/json`
#### Body Parameters
- **ProcessId** (`int`): İlerletmek istediğiniz sürecin numarası.
- **RequestId** (`int`): İlerletmek istediğiniz sürecin istek numarası.
- **EventId** (`int`): Süreci hangi eventttan devam ettirmek istiyorsanız o eventın numarası.
- **ReasonText** (`string`): Seçilen event eğer reason required ise bu kısım da doldurulmalıdır.
- **EventFormId** (`int`): Varsa event form numarası.
- **HasSigned** (`bool`): Süreç bir dokümansa ve imzalıysa true gönderilmelidir.