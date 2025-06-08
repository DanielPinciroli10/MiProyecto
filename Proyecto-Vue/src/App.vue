<template>
  <div class="contenedor">
    <nav>
      <router-link to="/alta">Alta de Gastos</router-link> |
      <router-link to="/lista">Listado de Gastos</router-link> 
    </nav>
    <router-view />
  </div>
</template>

<style scoped>
body {
  margin: 0;
  font-family: Arial, sans-serif;
  background-color: #f9f9f9;
}
.contenedor {
  width: 100%;
  padding: 20px;
  background-color: #ffffff;
  min-height: 100vh;
  font-size: 18px;
}
nav {
  margin-bottom: 20px;
  background-color: #e3f2fd;
  padding: 15px;
  border-radius: 8px;
  text-align: center;
}
nav a {
  margin: 0 15px;
  text-decoration: none;
  color: #333;
  font-weight: bold;
  font-size: 18px;
}
nav a.router-link-exact-active {
  color: #1976d2;
  text-decoration: underline;
}
</style>