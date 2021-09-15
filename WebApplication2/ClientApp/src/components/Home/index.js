import React, { useEffect } from 'react';
import userActions from '../../actions/user.actions';
import { useDispatch, useSelector } from 'react-redux';
//import cookies from 'browser-cookies';
//cookies.get('firstName');

const Home = () => {
    const dispatch = useDispatch();
    useEffect(() => {
      const token = localStorage.getItem("token")
        if (token)
          dispatch(userActions.getCurrentUser())
    }, []);
    const user = useSelector((state) => {
        return state.authentication.user})

    return (
        <div>
            {user.firstName ? 'Welcome' + user.firstName : <div>'Hello,stranger!'
                Please,login or register </div>}
           {/* {'Welcome' + userName}*/}
        </div>
    );
};
export default Home;