<template>

  <div class="container" >

    <h1>{{ title }}</h1>
    <h2>Produtos Cadastrados</h2>

    <b-alert :show="loading" variant="info">Loading...</b-alert>

          <b-button class="buttonCadastrar float-md-right" variant="success" size="md" to="/Products" >Cadastrar</b-button>
      
          <table class="table table-striped">
            <thead class="thead-blue">
              <tr>
                <th>Nome Produto</th>
                <th>Preço do Produto</th>
                <th>Data de Criação</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="record in records" :key="record.id">
                <td>{{ record.nome }}</td>
                <td> R$ {{ record.valor }}</td>
                <td>{{  $root.dateNow(record.data_criacao) }}</td>
                <td class="text-right">
                  <b-button variant="primary" v-on:click="abrir(record.id)">Edit</b-button> -
                  <b-button  variant="danger" @click.prevent="menssagemDelete(record.id)">Delete</b-button>
                </td>
              </tr>
            </tbody>
          </table>

  </div>

</template>

<script>

import axios from 'axios';

export default {

  data () {

	  return {
      title: 'Pos Controle',
      loading: false,
      records: {}
    }
    
  },

  async created() {
      this.getAll()
  },

  methods: {

      async getAll() {

        this.loading = true

        try {
          
          axios.get('https://localhost:5001/api/products/all').then(response => {
              this.records = response.data;
          });

        } finally {
          this.loading = false
        }

      },

      menssagemDelete(id) {

        this.$confirm("Você tem certeza que deseja deletar?","Atenção","info").then(() => { this.deleteProducts(id) });

      },

      async deleteProducts(id) {

          try 
          {

              let response = await axios.delete(`https://localhost:5001/api/products/delete/${id}`);

              location.reload();
              
          } catch (erro) {
              this.$alert(`Ocorreu um erro ao exluir o produto: ${erro}`);
          }

      },

      abrir(id) {
          this.$router.push({ path: `/Products/${id}` });
      }
    

   }

}

</script>
