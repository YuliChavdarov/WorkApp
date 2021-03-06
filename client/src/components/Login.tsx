import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';

import loginImage from '../images/login-image.jpg';

import { Link as RouterLink } from 'react-router-dom';

import { login } from '../services/UserService';
import AuthContext from '../contexts/AuthContext';
import Copyright from './Copyright';

export default function Login() {

    const authContext = React.useContext(AuthContext);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        const email = data.get('email')!.toString();
        const password = data.get('password')!.toString();

        const response = await login(email, password);

        if (response.errors) {
            console.log(response.errors);

        }
        else if (response.token) {
            authContext.login(response.token);
        }
    };

    return (
        <Container component="main"
            sx={{
                backgroundColor: "#fff",
                borderRadius: "10px",
                mt: 8
            }}
        >
            <CssBaseline />

            <Grid container>

                <Grid item md={5} display={{ xs: "none", md: 'block' }} sx={{ alignSelf: "center" }}>
                    <img
                        src={loginImage}
                        style={{ display: 'block', marginLeft: "auto", marginRight: "auto" }}
                        alt="login-img"
                    />
                </Grid>

                <Grid item md={7}>
                    <Box
                        sx={{
                            mt: 8,
                            mx: 4,
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center',
                        }}
                    >
                        <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                            <LockOutlinedIcon />
                        </Avatar>
                        <Typography component="h1" variant="h5">
                            Log in to WorkApp
                        </Typography>
                        <Box component="form" onSubmit={handleSubmit} width={{ xs: "100%", md: "80%" }} noValidate sx={{ mt: 1 }}>
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                id="email"
                                label="Email Address"
                                name="email"
                                autoComplete="email"
                                autoFocus
                            />
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                autoComplete="current-password"
                            />
                            <FormControlLabel
                                control={<Checkbox value="remember" color="primary" />}
                                label="Remember me"
                            />
                            <Button
                                type="submit"
                                fullWidth
                                variant="contained"
                                sx={{ mt: 3, mb: 2 }}
                            >
                                Log In
                            </Button>
                            <Grid container>
                                <Grid item xs>
                                    <Link href="#" variant="body2">
                                        Forgot password?
                                    </Link>
                                </Grid>
                                <Grid item>
                                    <Link component={RouterLink} to="/register" variant="body2">
                                        Don't have an account? Sign Up
                                    </Link>
                                </Grid>
                            </Grid>
                            <Copyright sx={{ mt: 6, mb: 4 }} />
                        </Box>
                    </Box>
                </Grid>
            </Grid>
        </Container>
    );
}