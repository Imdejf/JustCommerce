<template>
  <LineChart :chartData="testData" />
</template>

<script>
import { LineChart } from 'vue-chart-3'
import { Chart, registerables } from 'chart.js'

Chart.register(...registerables)
export default ({
  name: 'Home',
  components: { LineChart },
  setup () {
    const testData = {
      labels: ['Styczeń', 'Luty', 'Marzec'],
      datasets: [
        {
          data: [10, 20, 70],
          backgroundColor: ['#fad12c', '#3453b7', '#fa812d']
        }
      ]
    }

    return { testData }
  }
})
</script>
