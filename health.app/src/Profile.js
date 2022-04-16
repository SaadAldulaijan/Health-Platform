import React, {useState, useEffect} from "react";
import axios from 'axios';


const Profile = () => {
    const [user, setUser] = useState({});

    useEffect(() => {
        console.log('using effect');
        var url = "https://localhost:44302/api/Auth/user/saad";
        axios.get(url)
        .then(res => {
            console.log(res);
            setUser(res.data);
        })
        .catch(err => alert(err));
    }, [])

    return (
        <div>

            <div className="container">
                {user.username} - {user.id}
            </div>
            <div className="container">
                <img height={300} width={300} src={user.image} alt="profile-photo" />
            </div>
        </div>
    );
}

export default Profile;