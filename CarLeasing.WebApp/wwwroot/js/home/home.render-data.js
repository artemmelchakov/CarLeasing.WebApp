export class RenderData {
    // Отобразить список отфильтрованных офферов и их количество.
    static renderOffers(offersDto) {
        // Отображает количество
        $('.offers-count').text(offersDto.count);

        let tbody = $('.offers tbody');

        // Удаляем предыдущие строки таблицы
        tbody.children().remove();

        // Отрисовка таблицы
        for (var offer of offersDto.offers) {
            let tr = $('<tr>').appendTo(tbody);
            $('<td>').text(offer.brand).appendTo(tr);
            $('<td>').text(offer.model).appendTo(tr);
            $('<td>').text(offer.providerName).appendTo(tr);
            $('<td>').text(offer.registrationDate).appendTo(tr);
        }

        // Показываем элемент, содержащий все данные
        $('.offers').show();
    }

    // Отобразить список популярных поставщиков.
    static renderPopularProviders(popularProvidersDto) {
        let tbody = $('.popular-providers tbody');

        for (var provider of popularProvidersDto) {
            let tr = $('<tr>').appendTo(tbody);
            $('<td>').text(provider.name).appendTo(tr);
            $('<td>').text(provider.offersCount).appendTo(tr);
        }

        // Показываем элемент, содержащий все данные
        $('.popular-providers').show();;
    }
}