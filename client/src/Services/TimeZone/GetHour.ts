const date = new Date()

export const GetHour = () => {
    const dateH = date.getHours();

    if(dateH < 17 && (dateH > 7)){
        return "Buenos Días";
    } else if(dateH < 20) { 
        return "Buenas Tardes"; 
    } else return "Buenas Noches";
}
export const getDay = () => {

    const day = new Date().getDay();

    switch (day) {

        case 1: return "Lunes"; 
        case 2: return "Martes";
        case 3: return "Miercoles";
        case 4: return "Jueves";
        case 5: return "Viernes";
        case 6: return "Sabado";
        case 7: return "Domingo";
        default: return "Error getting Day";

    }
}