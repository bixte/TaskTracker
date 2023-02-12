# TaskTracker WebAPI
## Первое подключение:
Для работоспособности функционала потребуется поменять или добавить свою коннект ссылку на бд в appsettigns.json
## Функционал API:
Весь функционал представяет из себя crud для Projects а также ProjeсtTasks.
> ###### Для создания используется http-method = **Post**
> ###### Для просмотра используется http-method =**Get**
> ###### Для изменения используется http-method =**Put**
> ###### Для удаления используется http-method = **Delete**

##  Вариации сортировки и фильтрации Projects:
#### 1. FilterByStatus принимающий значение Enum(NotStarted, Active, Completed)
#### 2. SortByPriority принимающий значение Enum(Asc, Desc)
#### 3. Date **применяется вместе с typeSearchDate** для поиска определенной даты начала || определенной даты конца || от даты начала || до даты конца 

## Вариации сортировки и фильтрации Tasks:
#### 1. SortByPriority принимающий значение Enum(Asc, Desc)
#### 2. FilterByStatus принимающий значение Enum(ToDo, InProgress, Done)

