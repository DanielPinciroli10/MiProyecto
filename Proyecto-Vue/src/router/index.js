import { createRouter, createWebHistory } from 'vue-router'
import AltaGastos from '../views/AltaGastos.vue'
import ListadoGastos from '../views/ListadoGastos.vue'

const routes = [
    {
      path: '/lista',
      name: 'lista',
      component: ListadoGastos
    },
    {
      path: '/alta',
      name: 'Alta',
      component: AltaGastos
    } 
  ];
  const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

export default router;
