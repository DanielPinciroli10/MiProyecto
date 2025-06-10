<template>
  <form @submit.prevent="AltaGastos">
    <div><label>Monto:</label><input type="number" step="0.01" placeholder="Ingrese un monto" v-model.number="gasto.Monto" required /></div>
    <div><label>Descripción:</label><input type="text" placeholder="Ingrese la descripción" v-model="gasto.Descripcion" required /></div>
    <div><label>Fecha:</label><input type="date" v-model="gasto.Fecha" required /></div>
    <div><label>Comercio:</label><input type="text" placeholder="Ingrese el nombre del comercio" v-model="gasto.NombreComercio" required /></div>
    <button type="submit">Guardar</button>
    <p v-if="mensaje" :class="colorMensaje">{{ mensaje }}</p>
  </form>
</template>

<script setup>
  import {ref} from 'vue';
  const gasto = ref ({
      Monto: null,
      Descripcion: '',
      Fecha: '',
      NombreComercio: ''
  })
  const mensaje = ref ('');
  const colorMensaje = ref ('');
  async function AltaGastos () {
    if (
      !gasto.value.Monto || gasto.value.Monto <= 0 ||
      gasto.value.Descripcion.length < 3 || gasto.value.Descripcion.length > 250 ||
      !gasto.value.Fecha || new Date(gasto.value.Fecha) > new Date() ||
      !gasto.value.NombreComercio || gasto.value.NombreComercio.length > 250
    ) {
      mensaje.value = 'Ha ocurrido un error verifique los datos ingresados';
      return;
    }
    try {
      const respuesta = await fetch('http://localhost:5262/api/Gastos', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(gasto.value)
      });
      if (respuesta.ok) {
        console.log('guardado exitoso');
        mensaje.value = 'Los datos fueron guardados correctamente';
        colorMensaje.value = 'mensaje-Exitoso';
        LimpiarDatos();
      } else {
        mensaje.value = 'Error al guardar los datos ingresados';
        colorMensaje.value = 'mensaje-Error';
      }
    } catch (e) {
      mensaje.value = 'Error de conexión';
      colorMensaje.value = 'mensaje-Error';
    }
  }
  function LimpiarDatos() {
    gasto.value.Monto = null;
    gasto.value.Descripcion = '';
    gasto.value.Fecha = '';
    gasto.value.NombreComercio = ''
  }
  LimpiarDatos();
</script>
<style scoped>
form {
  max-width: 360px;
  margin: 20px auto;
  padding: 15px;
  border: 1px solid #ccc;
  border-radius: 6px;
  background: #fefefe;
  font-family: sans-serif;
}

div {
  margin-bottom: 12px;
}

label {
  display: block;
  font-weight: bold;
  margin-bottom: 4px;
}

input {
  width: 100%;
  padding: 6px 8px;
  border: 1px solid #aaa;
  border-radius: 4px;
  font-size: 14px;
}

button {
  padding: 8px 14px;
  background: #3498db;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background: #2980b9;
}

p {
  color: #e74c3c;
  text-align: center;
  margin-top: 10px;
  font-weight: bold;
}
.mensaje-Exitoso {
  color: green;
  font-weight: bold;
}
.mensaje-Error {
  color: red;
  font-weight: bold;
}
</style>

