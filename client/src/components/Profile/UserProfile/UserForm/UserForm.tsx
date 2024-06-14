import { useEffect, useState } from "react";
import styles from "./UserForm.module.css";
import { editUser, IUData } from "@/Services/Profile/UserDataManagment";

const UserForm = () => {
    
    const [formData,setFormData] = useState<IUData>({
        email:"",
        id:"",
        name:""
    });

    useEffect(() => {


    },[])

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            await editUser(formData);
            alert("se hicieron los cambios");
        } catch (error) {
            console.error("hubo un error", error);
        }

    }

    const handleChangeForm = (event: { target: { value: any; name?: any; }; }) => {
        const{name,value} = event.target;
        setFormData({...formData,
            [name]:value}
        );     
    }
    return (

        <form onSubmit={handleSubmit} action="" className="flex flex-col items-center">
            <fieldset className={`${styles.container__fieldset} border rounded-lg`}>
                <legend className="font-bold">Edita tus datos</legend>
                <div>                                   
                    <label className="text-violet-300 m-2">Nombre</label>             
                    <input className="border border-violet-300 rounded px-2 py-1 m-2 focus:outline-none focus:border-violet-500"
                    name="name" id="name" type="text"
                    onChange={handleChangeForm} />
                </div>
                <div>
                    <label className="text-violet-300 m-2">Email</label>
                    <input className="border border-violet-300 rounded px-2 py-1 m-2 focus:outline-none focus:border-violet-500"
                    name="email" id="email" type="email"
                    onChange={handleChangeForm} />
                </div>
            </fieldset>

            <button className="border-2 border-cards_border hover:bg-general_bg active:bg-general_bg text-white font-bold py-2 px-4 rounded mt-2"
            type="submit">Save</button>
        </form>

    )

}

export default UserForm;