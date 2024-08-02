export class MapData {
    // Получить информацию из строки поиска на странице.
    static mapSearchStringFromForm() {
        return $('.find-bar__search-input').val();
    }
}