#import <main/main.h>

extern "C" {
    const char* createApplicationScreenMessage() {
        NSString *message = [[Maincommon alloc] init].createApplicationScreenMessage;
        return strdup([message UTF8String]);
    }
}
