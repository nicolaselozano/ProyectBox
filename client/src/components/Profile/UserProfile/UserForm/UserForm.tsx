import styles from "./UserForm.module.css";

const UserForm = () => {
    
    return (

        <form action="" className="flex flex-col items-center">
            <fieldset className={`${styles.container__fieldset}`}>
                <legend>Edita tus datos</legend>
                <div>
                    <label htmlFor="nombre" className="m-2">Nombre</label>
                    <input className="m-2"
                    name="nombre" id="nombre" type="text"/>
                </div>
                <div>
                    <label className="m-2"
                    htmlFor="email">Email</label>
                    <input className="m-2"
                    name="email" id="email" type="email"/>
                </div>
            </fieldset>

            <fieldset className="flex justify-center">
                <legend>Tu especialidad</legend>
                <h1>Rol</h1>
            </fieldset>
        </form>

    )

}

export default UserForm;