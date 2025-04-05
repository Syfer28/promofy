import { create } from "zustand";

const useProductStore = create((set) => ({
  products: {},

  increaseCount: (product, idProduct) =>
    set((state) => ({
      products: {
        ...state.products,
        [idProduct]: state.products[idProduct]
          ? {
              ...state.products[idProduct],
              count: state.products[idProduct].count + 1,
            }
          : { ...product, count: 1 },
      },
    })),
  decreaseCount: (idProduct) =>
    set((state) => {
      const newProducts = { ...state.products };

      if (newProducts[idProduct]) {
        const newCount = newProducts[idProduct].count - 1;
        if (newCount > 0) {
          newProducts[idProduct] = {
            ...newProducts[idProduct],
            count: newCount,
          };
        } else {
          delete newProducts[idProduct];
        }
      }
      return { products: newProducts };
    }),
}));

export { useProductStore };
