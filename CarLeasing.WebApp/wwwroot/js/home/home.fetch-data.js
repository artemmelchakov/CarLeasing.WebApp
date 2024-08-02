export class FetchData {
    // Получить список офферов, отфильтрованный по строке поиска.
    static async offerGetListAsync(searchString) {
        return await fetch('/api/v1/offer/list?search=' + searchString, {
            mode: "no-cors",
            method: "GET"
        });
    }

    // Получить список популярных поставщиков.
    static async providerGetPopularAsync() {
        return await fetch('/api/v1/provider/popular', {
            mode: "no-cors",
            method: "GET"
        });
    }
}