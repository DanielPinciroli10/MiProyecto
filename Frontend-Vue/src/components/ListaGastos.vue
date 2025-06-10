<template>
  <div>
    <!-- <button @click="CargarGastos">Actualizar</button> -->
    <table v-if="gastos.length">
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Descripción</th>
          <th>Monto</th>
          <th>Comercio</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(gasto, indice) in gastos" :key="indice">
          <td>{{ gasto.fecha }}</td>
          <td>{{ gasto.descripcion }}</td>
          <td>${{ gasto.monto.toFixed(2) }}</td>
          <td>{{ gasto.nombreComercio }}</td>
        </tr>
      </tbody>
    </table>
    <p v-if="mensaje">{{ mensaje }}</p>
  </div>
</template>

<script setup>
import {ref, onMounted} from 'vue';
const gastos = ref ([]);
const mensaje = ref ('');
async function CargarGastos() {
    try {
      const respuesta = await fetch('http://localhost:5262/api/Gastos');
      gastos.value = await respuesta.json();
    } catch (e) {
      mensaje.value = 'Error al cargar los datos';
    }
  }
  onMounted(() => {
    CargarGastos();
  });
</script>
<style scoped>
div {
  max-width: 600px;
  margin: 20px auto;
  font-family: sans-serif;
}
button {
  padding: 6px 12px;
  margin-bottom: 10px;
  background-color: #3498db;
  border: none;
  color: white;
  border-radius: 4px;
  cursor: pointer;
}
button:hover {
  background-color: #2980b9;
}
table {
  width: 100%;
  border: 1;
  border-collapse: collapse;
}
td {
  padding: 8px 10px;
  border: 1px solid #ccc;
  text-align: center;
}
th {
  background-color: #a26363;
  color: #150606;
  padding: 10px;
  text-align: center;
  border-left: 10px;
}
p {
  color: #e74c3c;
  font-weight: bold;
  text-align: center;
  margin-top: 12px;
}
</style>
