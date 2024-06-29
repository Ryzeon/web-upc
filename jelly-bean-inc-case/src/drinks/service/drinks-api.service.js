import axios from "axios";

const http = axios.create({
   baseURL:  "https://jellybellywikiapi.onrender.com/api"
});

export class DrinksApiService {

    getDrinks() {
        return http.get("Beans");
    }
}