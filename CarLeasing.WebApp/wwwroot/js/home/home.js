import { FetchData } from './home.fetch-data.js';
import { MapData } from './home.map-data.js';
import { RenderData } from './home.render-data.js';

// Действия при загрузке страницы - загрузка офферов.
$(window).on('load', async function () {
    let response = await FetchData.offerGetListAsync("");
    if (response.status == 200) {
        let offersDto = await response.json();
        RenderData.renderOffers(offersDto);
    }
});
// Действия при загрузке страницы - загрузка популярных поставщиков.
$(window).on('load', async function () {
    let response = await FetchData.providerGetPopularAsync();
    if (response.status == 200) {
        let popularPorvidersDto = await response.json();
        RenderData.renderPopularProviders(popularPorvidersDto);
    }
});

// Действия при нажатии кнопки поиска офферов.
$('.find-bar__submit-button').on('click', async function () {
    let searchString = MapData.mapSearchStringFromForm();
    let response = await FetchData.offerGetListAsync(searchString);
    if (response.status == 200) {
        let offersDto = await response.json();
        RenderData.renderOffers(offersDto);
    }
});