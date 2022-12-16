#TaskTracker WebAPI
## Первое подключение:
Для работоспособности функционала потребуется поменять или добавить свою коннект ссылку на бд в appsettigns.json
## Функционал API:
Весь функционал представяет из себя crud для Projects а также ProjetTasks.
>Для создания используется http-method = **Post**
>Для просмотра используется http-method =**Get**
>Для изменения используется http-method =**Put**
>Для удаления используется http-method = **Delete**

## Вариации сортировки и фильтрации Projects:
FilterByStatus принимающий значение Enum(NotStarted, Active, Completed)
sortByPriority принимающий значение Enum(Asc, Desc)
date **применяется вместе с typeSearchDate** для поиска определенной даты начала ||определенной даты конца || от даты налача || до даты конца 

##Вариации сортировки и фильтрации Tasks:
sortByPriority принимающий значение Enum(Asc, Desc)
FilterByStatus принимающий значение Enum(ToDo, InProgress, Done)

