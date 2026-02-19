import Swal from 'sweetalert2';

export const CustomSwal = Swal.mixin({
  width: '380px',   // smaller width
  padding: '1.5rem',
  customClass: {
    popup: 'compact-swal'
  }
});

