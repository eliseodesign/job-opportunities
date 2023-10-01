import React from 'react';
import { Link } from 'react-router-dom';
import { useForm } from 'react-hook-form';

export function Register() {
  const { register, handleSubmit, formState: { errors } } = useForm();

  const onSubmit = async (data) => {
    try {
      const response = await fetch('api/auth/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(data), // Enviamos los datos del formulario como JSON
      });
  
      if (response.ok) {
        const responseData = await response.json();
  
        if (responseData.success) {
          // Registro exitoso, puedes redirigir al usuario a otra página o mostrar un mensaje de éxito
          console.log('Registro exitoso:', responseData.message);
        } else {
          // La API devolvió un error
          console.error('Error en el registro:', responseData.message);
        }
      } else {
        // Error en la solicitud (por ejemplo, error de red o servidor no responde)
        console.error('Error en la solicitud al servidor');
      }
    } catch (error) {
      // Error en la función fetch o en el procesamiento de la respuesta
      console.error('Error en la solicitud:', error);
    }
  };
  

  return (
    <>
      <section className="bg-gray-50">
        <div className="flex flex-col items-center justify-center px-6 py-8 mx-auto lg:py-0">
          <div className="w-full bg-white mt-4 rounded-lg shadow border md:mt-0 sm:max-w-md xl:p-0">
            <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
              <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl">
                Create an account
              </h1>
              <form className="space-y-4 md:space-y-6" onSubmit={handleSubmit(onSubmit)}>
                <div>
                  <label htmlFor="email" className="block mb-2 text-sm font-medium text-gray-900">Your e-mail</label>
                  <input
                    type="email"
                    name="email"
                    id="email"
                    className={`bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 ${errors.email ? 'border-red-500' : ''}`}
                    placeholder="name@company.com"
                    {...register("email", {
                      required: 'Email is required',
                      pattern: {
                        value: /^\S+@\S+$/i,
                        message: 'Invalid email address',
                      },
                    })}
                  />
                  {errors.email && <p className="text-red-500 text-sm mt-1">{errors.email.message}</p>}
                </div>
                <div>
                  <label htmlFor="password" className="block mb-2 text-sm font-medium text-gray-900">Password</label>
                  <input
                    type="password"
                    name="password"
                    id="password"
                    placeholder="••••••••"
                    className={`bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 ${errors.password ? 'border-red-500' : ''}`}
                    {...register("password", {
                      required: 'Password is required',
                    })}
                  />
                  {errors.password && <p className="text-red-500 text-sm mt-1">{errors.password.message}</p>}
                </div>
                <div>
                  <label htmlFor="firstName" className="block mb-2 text-sm font-medium text-gray-900">First Name</label>
                  <input
                    type="text"
                    name="firstName"
                    id="firstName"
                    className={`bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 ${errors.firstName ? 'border-red-500' : ''}`}
                    placeholder="First Name"
                    {...register("firstName", {
                      required: 'First Name is required',
                    })}
                  />
                  {errors.firstName && <p className="text-red-500 text-sm mt-1">{errors.firstName.message}</p>}
                </div>
                <div>
                  <label htmlFor="lastName" className="block mb-2 text-sm font-medium text-gray-900">Last Name</label>
                  <input
                    type="text"
                    name="lastName"
                    id="lastName"
                    className={`bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 ${errors.lastName ? 'border-red-500' : ''}`}
                    placeholder="Last Name"
                    {...register("lastName", {
                      required: 'Last Name is required',
                    })}
                  />
                  {errors.lastName && <p className="text-red-500 text-sm mt-1">{errors.lastName.message}</p>}
                </div>
                <div>
                  <label htmlFor="address1" className="block mb-2 text-sm font-medium text-gray-900">Address</label>
                  <input
                    type="text"
                    name="address1"
                    id="address1"
                    className={`bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 ${errors.address1 ? 'border-red-500' : ''}`}
                    placeholder="Address"
                    {...register("address1", {
                      required: 'Address is required',
                    })}
                  />
                  {errors.address1 && <p className="text-red-500 text-sm mt-1">{errors.address1.message}</p>}
                </div>
                <button
                  type="submit"
                  className="w-full bg-blue-600 text-white hover:bg-blue-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
                >
                  Sign in
                </button>
                <p className="text-sm font-light text-gray-500">
                  Don’t have an account yet? <Link to="/login" className="font-medium text-blue-600 hover:underline">Sign up</Link>
                </p>
              </form>
            </div>
          </div>
        </div>
      </section>
    </>
  );
}
