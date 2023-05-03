using webapi.Entity;

using (var ctx = new ClinicDbContext())
{
    //ctx.Users.AddRange(new List<User> {
    //    new User { FullName = "Oleh Diakiv", Login = "LogOleh", Password = "passOleh", Role = UserRole.Doctor},
    //     new User { FullName = "Liana Mazur", Login = "Liana", Password = "Liana", Role = UserRole.Patient},
    //});

    //ctx.Symptoms.AddRange(new List<Symptom>() {
    //    new Symptom() {Name = "Температура"},
    //    new Symptom() {Name = "Нежить"},
    //    new Symptom() {Name = "Кашель"},
    //    new Symptom() {Name = "Біль горла"},
    //    new Symptom() {Name = "Збільшення підчелюсних залоз"},
    //    new Symptom() {Name = "Віддих"},
    //    new Symptom() {Name = "Різна висипка"},
    //    new Symptom() {Name = "Тошнота, рвота"},
    //    new Symptom() {Name = "Опухлість завушних залоз"},
    //    new Symptom() {Name = "Болі в животі"},
    //    new Symptom() {Name = "Розлади кишківника"},
    //    new Symptom() {Name = "Пожовтіння шкіри голови"},
    //    new Symptom() {Name = "Головний біль"},
    //    new Symptom() {Name = "Озноб"},
    //    new Symptom() {Name = "Світлобоязнь"},
    //    new Symptom() {Name = "Сума вагових коефіцієнтів"},

    //});

    //ctx.Diseases.AddRange(
    //    new List<Disease>()
    //    {
    //        new Disease() {Name = "кір", Description = "антропонозна інфекційна хвороба, яку спричинює вірус з роду Morbillivirus. Характеризується вираженою автоінтоксикацією, гарячкою, запальними явищами з боку дихальних шляхів, кон'юнктивітом, появою своєрідних плям на слизовій оболонці ротової порожнини (плями Копліка) і папульозно-плямистим висипом на шкірі."},
    //        new Disease() {Name = "Грип", Description = "антропонозна інфекційна хвороба, яку спричинює вірус з роду Morbillivirus. Характеризується вираженою автоінтоксикацією, гарячкою, запальними явищами з боку дихальних шляхів, кон'юнктивітом, появою своєрідних плям на слизовій оболонці ротової порожнини (плями Копліка) і папульозно-плямистим висипом на шкірі."},
    //        new Disease() {Name = "Запалення легень", Description = "антропонозна інфекційна хвороба, яку спричинює вірус з роду Morbillivirus. Характеризується вираженою автоінтоксикацією, гарячкою, запальними явищами з боку дихальних шляхів, кон'юнктивітом, появою своєрідних плям на слизовій оболонці ротової порожнини (плями Копліка) і папульозно-плямистим висипом на шкірі."},
    //        new Disease() {Name = "Ангіна", Description = ""},
    //        new Disease() {Name = "Скарлатина", Description = ""},
    //        new Disease() {Name = "Свинка", Description = ""},
    //        new Disease() {Name = "Дизентерія", Description = ""},
    //        new Disease() {Name = "Гепатит", Description = ""},

    //    });

    //ctx.SaveChanges();
    ctx.Set<DiseaseSymptomValue>().AddRange(new List<DiseaseSymptomValue>()
    {
        new DiseaseSymptomValue(){ DiseaseId = 1, SymptomId = 1, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 1, SymptomId = 2, Value = 10 },
        new DiseaseSymptomValue(){ DiseaseId = 1, SymptomId = 3, Value = 10 },
        new DiseaseSymptomValue(){ DiseaseId = 1, SymptomId = 7, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 1, SymptomId = 15, Value = 30 },

        new DiseaseSymptomValue(){ DiseaseId = 2, SymptomId = 1, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 2, SymptomId = 2, Value = 10 },
        new DiseaseSymptomValue(){ DiseaseId = 2, SymptomId = 3, Value = 10 },
        new DiseaseSymptomValue(){ DiseaseId = 2, SymptomId = 13, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 2, SymptomId = 14, Value = 30 },

        new DiseaseSymptomValue(){ DiseaseId = 3, SymptomId = 1, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 3, SymptomId = 3, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 3, SymptomId = 6, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 3, SymptomId = 13, Value = 15 },
        new DiseaseSymptomValue(){ DiseaseId = 3, SymptomId = 14, Value = 15 },

        new DiseaseSymptomValue(){ DiseaseId = 4, SymptomId = 1, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 4, SymptomId = 4, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 4, SymptomId = 5, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 4, SymptomId = 13, Value = 15 },
        new DiseaseSymptomValue(){ DiseaseId = 4, SymptomId = 14, Value = 15 },

        new DiseaseSymptomValue(){ DiseaseId = 5, SymptomId = 1, Value = 15 },
        new DiseaseSymptomValue(){ DiseaseId = 5, SymptomId = 4, Value = 15 },
        new DiseaseSymptomValue(){ DiseaseId = 5, SymptomId = 5, Value = 10 },
        new DiseaseSymptomValue(){ DiseaseId = 5, SymptomId = 7, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 5, SymptomId = 8, Value = 30 },

        new DiseaseSymptomValue(){ DiseaseId = 6, SymptomId = 1, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 6, SymptomId = 5, Value = 30 },
        new DiseaseSymptomValue(){ DiseaseId = 6, SymptomId = 9, Value = 40 },

        new DiseaseSymptomValue(){ DiseaseId = 7, SymptomId = 1, Value = 20 },
        new DiseaseSymptomValue(){ DiseaseId = 7, SymptomId = 10, Value = 40 },
        new DiseaseSymptomValue(){ DiseaseId = 7, SymptomId = 11, Value = 40 },

        new DiseaseSymptomValue(){ DiseaseId = 8, SymptomId = 10, Value = 40 },
        new DiseaseSymptomValue(){ DiseaseId = 8, SymptomId = 12, Value = 60 },

    });
    ctx.SaveChanges();
}
