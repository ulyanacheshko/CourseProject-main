<template>
 <div class="container orders-container">
  <div class="orders-column">
    <h2>Заказы</h2>
    <div v-for="order in orders" :key="order.id" class="card">
      <h2>Order number: {{ order.id }}</h2>
      <p>Amount: {{ order.amount }}</p>
      <button @click="addToBasket(order)">Add to basket</button>
    </div>
  </div>
  <div class="basket-column">
    <h2>Корзина</h2>
    <div v-for="order in basket" :key="order.id" class="card">
      <h2>Order number: {{ order.id }}</h2>
      <p>Amount: {{ order.amount }}</p>
      <button @click="removeFromBasket(order)">Remove from basket</button>
    </div>
  </div>
</div>

</template>
 
<script>
import axios from 'axios';
 
export default {
  data() {
    return {
      orders: [],
      basket: [],
    };
  },
  methods: {
    async addToBasket(order) {
  console.log(`Adding ${order.text} to basket`);
  this.basket.push(order);
},
removeFromBasket(order) {
  const index = this.basket.indexOf(order);
  if (index !== -1) {
    this.basket.splice(index, 1);
  }
},
  },
  async created() {
    try {
      const response = await axios.get('https://localhost:7146/Order/orders');
      this.orders = response.data;
    } catch (error) {
      console.error(error);
    }
  },
};
</script>
 
<style scoped>
.container {
  background-color: #f2f2f2;
}

.column-heading {
  color: #333;
}

.order-number {
  color: #555;
}

.order-amount {
  color: #777;
}

.card {
  border: 1px solid #ccc;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.btn:hover {
  background-color: #0056b3;
  transform: translateY(-1px);
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.card {
  margin-bottom: 20px;
}

.orders-column {
  padding-right: 20px;
}

.basket-column {
  padding-left: 20px;
}

.card {
  border: 1px solid #ccc;
  padding: 20px;
  margin-bottom: 20px;
}

.container {
  display: flex;
}

.orders-column {
  flex: 1;
  padding-right: 20px;
}

.basket-column {
  flex: 1;
  padding-left: 20px;
}

.container {
  background-color: orange;
}

.column-heading {
  color: orange;
}

.order-number {
  color: orange;
}

.order-amount {
  color: orange;
}

.card {
  border-color: orange;
}

.btn:hover {
  background-color: orange;
}

</style>