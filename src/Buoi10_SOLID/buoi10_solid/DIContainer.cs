using System;
using System.Collections.Generic;
using System.Reflection;

public class DIContainer
{
    // thuộc tính
    // registrations là một dict lưu trữ các dịch vụ đã đăng ký
    // key là kiểu dịch vụ (interface) và value là kiểu triển khai (class)
    private Dictionary<Type, Type> registrations = new Dictionary<Type, Type>();

    // Đăng ký 1 service: interface + implement
    // thêm ràng buộc cho TImplementation là lớp con của TService
    // TService là interface, TImplementation là lớp triển khai
    public void Register<TService, TImplementation>()
    {
        // thêm vào dict registrations
        registrations[typeof(TService)] = typeof(TImplementation);
    }

    // Tạo instance (có inject phụ thuộc nếu cần)
    // return ra một instance của TService
    //Hàm này dùng cho bên ngoài container gọi:

    //Viết đơn giản, tiện lợi, có IntelliSense, an toàn kiểu (type safety).
    public TService Resolve<TService>()
    {
        return (TService)Resolve(typeof(TService));
        // gọi hàm Resolve(Type serviceType) để lấy instance
    }


// Đây là hàm “thực thi thực sự”, xử lý logic tạo instance động.
    private object Resolve(Type serviceType)
    {
        // Nếu là interface, lấy implementation đã đăng ký
        if (registrations.ContainsKey(serviceType))
        {
            Type implementationType = registrations[serviceType];
            return CreateInstance(implementationType);
        }
        // Nếu là class cụ thể, tự tạo instance
        else if (!serviceType.IsAbstract)
        {
            return CreateInstance(serviceType);
        }
        else
        {
            throw new Exception($"Service chưa được đăng ký: {serviceType.Name}");
        }
    }

    // Tạo instance, inject phụ thuộc qua constructor
    private object CreateInstance(Type type)
    {
        // Lấy constructor đầu tiên (có thể chọn constructor nhiều tham số nhất)
        ConstructorInfo constructor = type.GetConstructors()[0];
        // Lấy danh sách tham số của constructor
        ParameterInfo[] parameters = constructor.GetParameters();

        // Nếu không có tham số, tạo instance luôn
        if (parameters.Length == 0)
        {
            return Activator.CreateInstance(type);
        }

        // Nếu có tham số, tạo instance của từng tham số rồi truyền vào
        object[] parameterInstances = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterInstances[i] = Resolve(parameters[i].ParameterType);
        }
        return constructor.Invoke(parameterInstances);
    }
}