<template>

  <div id="produtos-form" class="container mt-2">

    <div class="d-flex align-items-center justify-content-between mb-3">
      <h1 class="titulo">Formulário de Produto</h1>
      <b-button variant="secondary" size="md" @click="$router.push({ path: '/' })" >
        Voltar
      </b-button>
    </div>

    <b-form @submit="onSubmit($event)">

      <b-form-group label="Nome do Produto:" label-for="nome" class="texto-esquerda">
        <b-form-input name="nome" id="nome" v-model="form.nome" type="text" required placeholder="Nome do Produto"></b-form-input>
      </b-form-group>

      <b-form-group   label="Valor(R$):" label-for="valor" class="texto-esquerda">
        <input name="valor" id="valor" v-model="form.valor" v-money="moeda" class="form-control" type="text" required placeholder="Valor do Produto(UND)" />
      </b-form-group>
      

      <b-form-group label="Categoria:" label-for="categoria" class="texto-esquerda">
          <b-form-select v-model="form.categoria" :options="options"></b-form-select>
      </b-form-group>

      <b-button type="submit" variant="success float-md-right" size="md" class="mr-3">
        Salvar
      </b-button>

    </b-form>
  </div>
</template>

<script>

import axios from 'axios';
import {mask} from 'vue-the-mask';
import {VMoney} from 'v-money';
import qs from 'qs';


export default {

  data() {

    return {

      form: {valor:0, categoria: null},
      options: [
        { value: null, text:  'Selecione' },
        { value: 0,    text:  'Roupas/Calçados' },
        { value: 1,    text:  'Videogames' },
        { value: 2,    text:  'Eletrodoméstico' },
        { value: 3,    text:  'Informática' },
        { value: 4,    text:  'Telefonia'},
        { value: 5,    text:  'Som'},
      ],
      moeda: {
        decimal: ',',
        thousands: '.',
        suffix: '',
        precision: 2,
        masked: false
      },
      id: this.$route.params.id

    };

  },

  async created() {

    if (this.id) {
        this.obterProdutos(this.id);
    }

  },

  methods:{
    
    onSubmit(e) {

      e.preventDefault();

      if (!this.id) {
          this.create();
          return false;
      }

      this.atualizar(this.id);

      return false;
    },


    async obterProdutos(id) {

      let response = await axios.get(`https://localhost:5001/api/products/search/${id}`);
      
      this.form       = response.data;
      
    },

    async create() {

        try {

            await axios.post
            (
                
                'https://localhost:5001/api/products/insert', 
                qs.stringify( 
                              { 
                                nome: this.form.nome, 
                                valor: this.form.valor,
                                categoria: this.form.categoria, 
                                data_criacao: this.$root.dateNow() 
                              }),
                { 
                  headers:  {  'Content-Type': 'application/x-www-form-urlencoded' }
                }

            );

            this.$router.push({ path: '/' });

        } catch (erro) {
            this.$alert("Ocorreu um erro ao inserir o produto:",erro);
        }

    },

    

    async atualizar(id) {

        try {

          await axios.put
          (

            `https://localhost:5001/api/products/update/${id}`,
              {

                id            : id,
                nome          : this.form.nome,
                valor         : this.$root.removeNonDigits(this.form.valor), 
                categoria     : this.form.categoria, 
                data_criacao  : new Date(this.form.data_criacao)

              }

          );

          this.$router.push({ path: '/' });

        } catch (erro) {
            this.$alert(`Ocorreu um erro ao atualizar o cliente: ${erro}`);
        }

    },

  },

  directives: {money: VMoney}

};
</script>

