import { html, render } from "../node_modules/lit-html/lit-html.js";
import { towns } from "./towns.js";

const searchTemplate = (towns, match) => html`

   <article>
        <div id="towns">
         <ul>
         ${towns.map(town => html `     
         <li class = ${match && town.toLowerCase().includes(match.toLowerCase()) ? 'active' : ''}>
               ${town}
         </li>
         `)}
         </ul>
        </div>
        <input type="text" id="searchText" />
        <button @click=${search}>Search</button>
        <div id="result">${countMatches(towns, match)}</div>
    </article>
`;

const main = document.body;
update();

function update(match = '') {

   const result = searchTemplate(towns, match);  
   render(result, main);

}

function search() {

   const match = document.getElementById('searchText').value;
   document.getElementById('searchText').value = '';
   update(match);
}

function countMatches(towns, match) {

   const matches = towns.filter(t => match && t.toLowerCase().includes(match.toLowerCase())).length;

   return `${matches} matches found`;
}
