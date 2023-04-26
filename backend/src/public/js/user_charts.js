/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the project
    @copyright: DamijodaStudios
    
 */

function random_color(alpha=1.0){
    const r_c = Math.round(Math.random() * 255);
    return `rgba(${r_c}, ${r_c}, ${r_c}, ${alpha})`;
} //funcion para generar colores aleatorios

Chart.defaults.font.size = 18; //tamaño de la fuente de los graficos


