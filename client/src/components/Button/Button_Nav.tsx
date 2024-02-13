import Link from "next/link";

interface Label {

    children:React.ReactNode,
    to:string
}

const Button_Nav:React.FC<Label> = ({children,to}:Label) => {

    return (

        <Link href={to}>
            <div className="bg-green-600 hover:bg-green-800 text-white font-bold py-2 px-4 rounded mt-2">
            {children}
            </div>
        </Link>
    )

}

export default Button_Nav;