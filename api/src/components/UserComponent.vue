<template>
  <div class="container registration-container">
    <div class="registration-column">
      <h2>Регистрация</h2>
      <div class="card">
        <div class="form-group">
          <label for="username">Имя пользователя:</label>
          <input id="username" v-model="newUser.Username" type="text" class="input-field" />
        </div>
        <div class="form-group">
          <label for="password">Пароль:</label>
          <input id="password" v-model="newUser.Password" type="password" class="input-field" />
        </div>
        <div class="form-group">
          <label for="id">ID:</label>
          <input id="id" v-model.number="newUser.Id" type="number" class="input-field" />
        </div>
        <button @click="registerUser" class="btn">Зарегистрировать</button>
      </div>
    </div>
    <div class="users-column">
      <h2>Пользователи</h2>
      <div v-for="user in Users" :key="user.Id" class="card user-card">
  <h2>User ID: {{ user.Id }}</h2>
  <p>Username: {{ user.Username }}</p>
  <p>Password: {{ user.Password }}</p>
</div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      Users: [],
      newUser: {
        Username: '',
        Password: '',
        Id: null,
      },
    };
  },
  methods: {
    async registerUser() {
      try {
        const response = await axios.post('https://localhost:7146/User/register', this.newUser);
        const registeredUser = response.data;
        this.Users.unshift(registeredUser);
        this.newUser.Username = '';
        this.newUser.Password = '';
        this.newUser.Id = null;
        console.log('User registered:', registeredUser);
        this.fetchUsers(); 
      } catch (error) {
        console.error('Error registering user:', error);
      }
    },
    async fetchUsers() {
  try {
    const response = await axios.get('https://localhost:7146/User/Users');
    this.Users = response.data.map(user => ({
      ...user,
      Username: user.username,
      Password: user.password,
      Id: user.id
    }));
  } catch (error) {
    console.error('Error getting users:', error);
  }
},
  },
  created() {
    this.fetchUsers(); 
  },
};
</script>

<style scoped>
.container {
  display: flex;
  justify-content: space-between;
  padding: 20px;
}

.registration-column {
  flex: 1;
  padding-right: 20px;
  margin-left: 20px;
}

.users-column {
  flex: 1;
}

.card {
  border: 1px solid #ccc;
  padding: 20px;
  margin-bottom: 20px;
  border-radius: 6px;
  background-color: #f5f5f5;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

h2 {
  margin-top: 0;
}

.form-group {
  margin-bottom: 15px;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 5px;
}

.input-field {
  width: 100%;
  padding: 10px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
  transition: border-color 0.3s ease;
  box-sizing: border-box;
}

.input-field:focus {
  outline: none;
  border-color: #ff9800; 
}

.btn {
  display: block;
  margin-top: 20px;
  padding: 10px 20px;
  font-size: 16px;
  cursor: pointer;
  background-color: #ff9800; 
  color: #fff;
  border: none;
  border-radius: 4px;
  transition: background-color 0.3s ease;
}

.btn:hover {
  background-color: #ff6600; 
}
</style>