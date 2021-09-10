import { Redirect } from "react-router-dom";
const Logout = () => {

    localStorage.clear(token);
        return <Redirect to="/" />
    
}
export default Logout;