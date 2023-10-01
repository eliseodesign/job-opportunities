import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

export const ConfirmAccount = () => {
  const { token } = useParams();
  const [confirmationStatus, setConfirmationStatus] = useState('Loading...');

  useEffect(() => {
    const fetchConfirmation = async () => {
      try {
        const response = await fetch(`/api/auth/verify?token=${token}`);
        
        if (!response.ok) {
          throw new Error('No se pudo confirmar la cuenta');
        }

        const data = await response.json();
        // Manejar la respuesta exitosa aquí si es necesario
        setConfirmationStatus(data.message); // Cambia data.message según la estructura de la respuesta
      } catch (error) {
        // Manejar errores de la solicitud aquí
        console.error(error);
        setConfirmationStatus('Error al confirmar la cuenta');
      }
    };

    fetchConfirmation();
  }, [token]);

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-200">
      <div className="bg-white text-teal-900 p-6 rounded-lg shadow-md">
        <h1 className="text-2xl font-bold mb-4 ">Confirmación de Cuenta</h1>
        <p className="text-lg mb-4 ">Estado de confirmación: {confirmationStatus}</p>
      </div>
    </div>
  );
};
