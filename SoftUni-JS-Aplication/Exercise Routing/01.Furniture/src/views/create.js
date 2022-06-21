import { createItem } from "../api/data.js";
import { html } from "../lib.js";

const createTemplate = (errorMsg, errors) => html`

<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        ${errorMsg ? html`<div class="form-group error">${errorMsg}</div>` : null}
    </div>
</div>
<form>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class="${'form-control' + (errors.make ? ' is-invalid' : '')}" id="new-make" type="text" name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (errors.model ? ' is-invalid' : '')} id="new-model" type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (errors.year ? ' is-invalid' : '')} id="new-year" type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (errors.description ? ' is-invalid' : '')} id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (errors.price ? ' is-invalid' : '')} id="new-price" type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (errors.img ? ' is-invalid' : '')} id="new-image" type="text" name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Create" />
        </div>
    </div>
</form>
`;


export function createPage(ctx) {

    update(null, {});

    function update(errorMsg, errors) {

        ctx.render(createTemplate(errorMsg, errors));

    }

    const form = document.querySelector('form');

    form.addEventListener('submit', async (e) => {

        e.preventDefault();
        const formData = [...(new FormData(form)).entries()];

        const data = formData.reduce((a, [k, v]) => Object.assign(a, { [k]: v.trim() }), {});

        const missing = formData.filter(([k, v]) => k != 'material' && v.trim() == '');

        try {

            const errors = missing.reduce((a, [k]) => Object.assign(a, {[k]: true}), {});

            if (missing.length > 0) {
                
                throw {

                    error: new Error('Please fill all mandatory fields!'),
                    errors

                };
            }

            data.year = Number(data.year);
            data.price = Number(data.price);

            if (data.price < 0) {

                throw {

                    error: new Error('Price must be positive!'),
                    errors
                };

            }
            if (data.year < 1950 || data.year > 2050) {

                throw {

                    error: new Error('Year must be betweem 1950 and 2050!'),
                    errors
                };

            }
            if (data.description.length < 10) {

                throw {

                    error: new Error('Description must be more than 10 symbols'),
                    errors
                };

            }
            if (data.model.length < 4 || data.make.length < 4) {

                throw {

                    error: new Error('Model and Make must be more 4 symbols'),
                    errors
                };

            }

            const result = await createItem(data);
            form.reset();
            ctx.page.redirect('/details/' + result._id);
        } catch (err) {

            const message = err.message || err.error.message;

            update(message, err.errors || {});
        }
    });
}