/**
    @author: DamijodaStudios
    @version: 1.0.0
    @description: main file of the project
    @copyright: DamijodaStudios
    
 */

//Imports

Chart.defaults.font.size = 16;

try{
    // Obtener los datos de los usuarios con más partidas
async function getUserData() {
    const response = await fetch('/api/users');
    const data = await response.json();
    return data;
  }
  
  // Configurar el gráfico
  async function setupChart() {
    const data = await getUserData();
    const usernames = data.map(d => d.username);
    const numMatches = data.map(d => d.num_matches);
  
    const ctx = document.getElementById('apiChart1').getContext('2d');
    const chart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: usernames,
        datasets: [{
          label: 'Usuarios con más partidas',
          data: numMatches,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
  
  // Llamar a la función de configuración del gráfico
  setupChart();
  


}catch(error){
    console.log(error);
}

try {

    async function getCharactersData() {
      const response = await fetch('/api/characters');
      const data = await response.json();
      return data;
    }
  
    async function setupChart() {
      const data = await getCharactersData();
      const characterNames = data.map(d => d.character_name);
      const numMatches = data.map(d => d.num_matches);
  
      const ctx = document.getElementById('apiChart2').getContext('2d');
      const chart = new Chart(ctx, {
        type: 'pie',
        data: {
          labels: characterNames,
          datasets: [{
            label: 'Personajes mas usados',
            data: numMatches,
            backgroundColor: [
              'rgba(231, 76, 60, 1)',
              'rgba(142, 68, 173, 1)',
              'rgba(41, 128, 185, 1)',
            ],
            borderColor: [
              'rgba(231, 76, 60, 1)',
              'rgba(142, 68, 173, 1)',
              'rgba(41, 128, 185, 1)',
            ],
            borderWidth: 1
          }]
        },
        options: {
          responsive: true,
          plugins: {
            legend: {
              position: 'bottom'
            },
            title: {
              display: true,
              text: 'Personajes mas usados'
            }
          }
        }
      });
    }
    setupChart();
  
  } catch (error) {
    console.log(error);
  }
  


